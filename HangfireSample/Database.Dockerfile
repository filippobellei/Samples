FROM mcr.microsoft.com/mssql/server

ENV ACCEPT_EULA="Y"
ENV MSSQL_SA_PASSWORD="r3iEPjoKysSu6h8k6OdTCBdQ1PgmzkXuNhyc5h8GxGqEgkdu5FqZmQEE31hK0Cm6BnJHgncsh4sp1nXuNnz5Fw"

EXPOSE 1433
VOLUME /var/opt/mssql
