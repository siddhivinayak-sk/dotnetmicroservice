FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyProject/MyProject.csproj", "MyProject/"]
COPY ["MyProject.Core/MyProject.Core.csproj", "MyProject.Core/"]
COPY ["MyProject.Infrastructure/MyProject.Infrastructure.csproj", "MyProject.Infrastructure/"]
RUN dotnet restore "MyProject/MyProject.csproj"
COPY . .
WORKDIR "/src/MyProject"
RUN dotnet build "MyProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProject.dll"]
