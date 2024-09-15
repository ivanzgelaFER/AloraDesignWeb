FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
RUN apt-get update -y
RUN apt-get install -y cron
RUN apt-get install -y nano
RUN apt-get install -y apt-transport-https
RUN apt-get install -y wget
RUN wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt-get update -y
RUN apt-get install -y dotnet-sdk-8.0
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AloraDesign/AloraDesign.csproj", "AloraDesign/"]
COPY ["AloraDesign.Domain/AloraDesign.Domain.csproj", "AloraDesign.Domain/"]
COPY ["AloraDesign.Data/AloraDesign.Data.csproj", "AloraDesign.Data/"]
RUN dotnet restore "AloraDesign/AloraDesign.csproj"
COPY . .
WORKDIR /src/AloraDesign/ClientApp/
RUN curl -sL https://deb.nodesource.com/setup_18.x |  bash -
RUN apt-get install -y nodejs
RUN npm install
WORKDIR "/src/AloraDesign"
RUN dotnet build "AloraDesign.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "AloraDesign.csproj" -c Release -o /app/publish
FROM base AS final
RUN dotnet dev-certs https --trust
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AloraDesign.dll"]