FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ApiASPLinux.csproj", "./"]
RUN dotnet restore "./ApiASPLinux.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ApiASPLinux.csproj" -c Release -o /app/build

FROM build AS publish
COPY ./entrypoint.sh ./app/
RUN chmod +x ./app/entrypoint.sh
CMD /bin/bash ./app/entrypoint.sh
RUN dotnet publish "ApiASPLinux.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiASPLinux.dll"]
