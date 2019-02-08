# Webservice2

This project is a usual web api on top of a SQL Server database.
The database is run inside a docker container. 

## Run a dockerized SQL Server

Follow the instructions here:
https://hub.docker.com/r/microsoft/mssql-server-linux/

``` bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<sa_password>' -p 1433:1433 -d microsoft/mssql-server-linux:2017-CU8
```  

## SQL Client
Dbeaver seems to be popular: https://dbeaver.io

Azure Data Studio is gaining momentum so let's gor for it :https://docs.microsoft.com/en-us/sql/azure-data-studio/

You may install the extension `newdatabase` to create a database from a simple click

## Scaffolding Entity Framework core

```bash
 dotnet ef dbcontext scaffold "Data Source={sqlServer};Initial Catalog={sqlDbName};User Id={sqlLogin};Password={sqlPassword}" Microsoft.EntityFrameworkCore.SqlServer
``` 
This creates a masterContext.cs file with a dbcontext class.
