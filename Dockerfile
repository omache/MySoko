# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o /out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /out .

EXPOSE 80

# Run migrations before starting the application
ENTRYPOINT ["bash", "-c", "dotnet ef database update && dotnet MySoko.dll"]
