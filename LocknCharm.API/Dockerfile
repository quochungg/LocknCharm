# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and restore
COPY *.sln .
COPY LocknCharm.API/*.csproj ./LocknCharm.API/
COPY LocknCharm.Application/*.csproj ./LocknCharm.Application/
COPY LocknCharm.Domain/*.csproj ./LocknCharm.Domain/
COPY LocknCharm.Infrastructure/*.csproj ./LocknCharm.Infrastructure/

RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Publish the API project
WORKDIR /src/LocknCharm.API
RUN dotnet publish -c Release -o /app/publish

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port (adjust if needed)
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "LocknCharm.API.dll"]
