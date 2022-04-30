#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HospR.WebAPI/HospR.WebAPI.csproj", "HospR.WebAPI/"]
RUN dotnet restore "HospR.WebAPI/HospR.WebAPI.csproj"
COPY . .
WORKDIR "/src/HospR.WebAPI"
RUN dotnet build "HospR.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HospR.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HospR.WebAPI.dll"]