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

To run Azure Data Studio:
```bash
azuredatastudio
```

You may install the extension `newdatabase` to create a database from a simple click

## Scaffolding Entity Framework core

```bash
 dotnet ef dbcontext scaffold "Data Source={sqlServer};Initial Catalog={sqlDbName};User Id={sqlLogin};Password={sqlPassword}" Microsoft.EntityFrameworkCore.SqlServer
``` 
This creates a masterContext.cs file with a dbcontext class. You need to keep the overriding of the method `OnConfiguring` so the ef migration commands:
```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer(<connection_string>);
    }
}
```

You need to add new `DbSet<T>` to this class.

## Entity framework migration

The following steps come from https://docs.microsoft.com/fr-fr/ef/core/managing-schemas/migrations/


Create a migration named `InitialCreate` (you may choose any name you want)
``` bash
dotnet ef migrations add InitialCreate
```
A folder Migrations is created with auto generated files.

Then apply the changes to the database:

```
dotnet ef database update
```
