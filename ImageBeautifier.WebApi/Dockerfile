FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ImageBeautifier.WebApi/ImageBeautifier.WebApi.csproj", "ImageBeautifier.WebApi/"]
RUN dotnet restore "ImageBeautifier.WebApi/ImageBeautifier.WebApi.csproj"
COPY . .
WORKDIR "/src/ImageBeautifier.WebApi"
RUN dotnet build "ImageBeautifier.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ImageBeautifier.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ImageBeautifier.WebApi.dll"]
