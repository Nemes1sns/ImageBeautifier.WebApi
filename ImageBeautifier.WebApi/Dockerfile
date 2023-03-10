FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
 
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
 
COPY . ./
RUN dotnet build -o /app
RUN dotnet publish -o /publish
 
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
COPY --from=build  /publish /app

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5200/
EXPOSE 5200

WORKDIR /app
CMD ["./ImageBeautifier.WebApi"]