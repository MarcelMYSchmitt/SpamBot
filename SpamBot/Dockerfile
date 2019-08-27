FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY SpamBot/SpamBot.csproj SpamBot/
RUN dotnet restore SpamBot/SpamBot.csproj
COPY . .
WORKDIR /src/SpamBot
RUN dotnet build SpamBot.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SpamBot.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SpamBot.dll"]
