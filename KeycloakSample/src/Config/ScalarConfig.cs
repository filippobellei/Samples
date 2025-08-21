using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

namespace KeycloakSample.Config;

public static class ScalarConfig
{
    public static IHostApplicationBuilder AddScalar(this IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var keycloakConfig = builder.Configuration.GetRequiredSection("Keycloak");
        var authority = keycloakConfig["Authority"];

        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, _, _) =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(authority + "/protocol/openid-connect/auth"),
                            TokenUrl = new Uri(authority + "/protocol/openid-connect/token")
                        }
                    }
                };

                document.Components ??= new OpenApiComponents();
                document.Components.SecuritySchemes.Add(nameof(SecuritySchemeType.OAuth2), securityScheme);

                return Task.CompletedTask;
            });
        });

        return builder;
    }

    public static WebApplication MapScalar(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var keycloakConfig = app.Configuration.GetRequiredSection("Keycloak");
        var oAuth2 = nameof(SecuritySchemeType.OAuth2);

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options => options
                .AddPreferredSecuritySchemes(oAuth2)
                .AddAuthorizationCodeFlow(oAuth2, flow =>
                {
                    flow.ClientId = keycloakConfig["ClientId"];
                    flow.Pkce = Pkce.Sha256;
                })
            );
        }

        return app;
    }
}
