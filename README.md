dotnet new sln -o eshop-microservices


dotnet new web  -> creates a new empty web project 

dotnet sln add ./folder-to/csproj


dotnet dev-certs https --trust

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = Status307TemporaryRedirect;
    options.HttpsPort = 5050;
});

dotnet add package Mediatr