# Use the official .NET image as a build stage
FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookStore.csproj", "./"]
RUN dotnet restore "./BookStore.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BookStore.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "BookStore.csproj" -c Release -o /app/publish

# Use the base image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.dll"]
