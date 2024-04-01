sudo aa-remove-unknown

dotnet new sln -o eshop-microservices

dotnet new web -> creates a new empty web project

dotnet sln add ./folder-to/csproj

dotnet dev-certs https --trust

builder.Services.AddHttpsRedirection(options =>
{
options.RedirectStatusCode = Status307TemporaryRedirect;
options.HttpsPort = 5050;
});

dotnet add package Mediatr

dotnet new classlib

# using Carter to create endpoints

dotnet add package carter

AddCarter
MapCarter

# using Mapster to map objects

dotnet add package Mapster

# use Marten to treat Postgresql as a .NET transactional Document DB

# adding to Catalog Api

dotnet add package Marten

IDocumentSession on primary constructor of the handler

docker compose -f docker-compose.yml -f docker-compose.override.yml up -d

docker exec -it pg sh

psql -U postgres

\l

\c databasename

\d

# fluent validation common to all services, adding it to buildingblocks

dotnet add package fluentvalidation.dependencyinjectionextensions

# adds aspnet capabilities to building blocks in order to use Global Exception Handling

FluentValidation.AspNetCore
