#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eDnevnikDodatni/eDnevnikDodatni.csproj", "eDnevnikDodatni/"]
RUN dotnet restore "eDnevnikDodatni/eDnevnikDodatni.csproj"
COPY . .
WORKDIR "/src/eDnevnikDodatni"
RUN dotnet build "eDnevnikDodatni.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eDnevnikDodatni.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eDnevnikDodatni.dll"]