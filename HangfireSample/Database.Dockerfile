FROM mcr.microsoft.com/mssql/server

ENV ACCEPT_EULA="Y"
ENV MSSQL_SA_PASSWORD="8f8e9280-8859-4443-b00e-aee7acc91fb2"

EXPOSE 1433
VOLUME /var/opt/mssql