FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish EcoStepBackend/EcoStepBackend/EcoStepBackend.csproj -c Release -o /app/publish
RUN cp -r Front /app/publish/Front/

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "EcoStepBackend.dll"]
