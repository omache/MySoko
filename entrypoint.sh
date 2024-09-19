#!/bin/sh
set -e

# Run migrations
dotnet ef database update --project YourProject.csproj --startup-project YourStartupProject.csproj

# Start the application
exec dotnet MySoko.dll
