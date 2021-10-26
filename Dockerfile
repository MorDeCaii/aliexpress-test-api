# httpshub.docker.com_microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Categories.API/*.csproj ./Categories.API/
COPY Categories.Core/*.csproj ./Categories.Core/
COPY Categories.DAL/*.csproj ./Categories.DAL/
COPY Categories.BLL/*.csproj ./Categories.BLL/
RUN dotnet restore

# copy everything else and build app
COPY Categories.API/. ./Categories.API/
COPY Categories.Core/. ./Categories.Core/
COPY Categories.DAL/. ./Categories.DAL/
COPY Categories.BLL/. ./Categories.BLL/
WORKDIR /source/Categories.API
RUN dotnet publish -c release -o /app --no-restore

# final stageimage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Categories.API.dll"]