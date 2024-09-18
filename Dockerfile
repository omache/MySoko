# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container to /app
WORKDIR /app

# Copy the csproj file(s) and restore the NuGet packages
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application files
COPY . ./

# Build the application
RUN dotnet publish -c Release -o /out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory in the container to /app
WORKDIR /app

# Copy the build artifacts from the first stage
COPY --from=build /out .

# Expose port 80 to allow web traffic
EXPOSE 80

# Set the entrypoint for the container to run the application
ENTRYPOINT ["dotnet", "MySoko.dll"]
