# build sections
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source/

# copies .sln files from one folder to current folder (source)
COPY *.sln .
COPY RatingRestaurantsApp/*.csproj ./RatingRestaurantsApp/
# restoring dependencies
RUN dotnet restore 

COPY RatingRestaurantsApp/. ./RatingRestaurantsApp/
WORKDIR /source/RatingRestaurantsApp/
RUN dotnet publish -c release -o /app --no-restore

# runtime section
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "RatingRestaurantsApp.dll"]