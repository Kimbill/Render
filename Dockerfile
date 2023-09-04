#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR "/RenderSample"
COPY ["RenderSample.csproj", "RenderSample/"]
RUN dotnet restore "RenderSample.csproj"
COPY . .
WORKDIR "/RenderSample"
RUN dotnet build "RenderSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RenderSample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR "/RenderSample/RenderSample"
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet RenderSample.dll
#ENTRYPOINT ["dotnet", "RenderSample.dll"]