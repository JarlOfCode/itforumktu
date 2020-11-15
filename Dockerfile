# Dockerfile

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
#WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore

# Copy everything else and build
#COPY . .
#RUN dotnet publish -c Release -o out

# Build runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
#WORKDIR /app
#COPY --from=build-env /app/out .

# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
#ENTRYPOINT [ "dotnet", "itforumktu.dll" ]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet ITForumV3.dll

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ITForumV3.csproj", ""]
RUN dotnet restore "./ITForumV3.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ITForumV3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITForumV3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "GameReviews.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ITForumV3.dll