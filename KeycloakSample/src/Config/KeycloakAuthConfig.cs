using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace KeycloakSample.Config;

public static class KeycloakAuthConfig
{
    public static IHostApplicationBuilder AddKeycloakAuth(this IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var keycloakConfig = builder.Configuration.GetRequiredSection("Keycloak");

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = keycloakConfig["Authority"];
                options.Audience = keycloakConfig["ClientId"];
                options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
            });

        builder.Services.AddAuthorization();

        return builder;
    }
}
