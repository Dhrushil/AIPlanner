FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Planner-Backend/Planner-Backend.csproj", "Planner-Backend/"]
RUN dotnet restore "Planner-Backend/Planner-Backend.csproj"
COPY . .
WORKDIR "/src/Planner-Backend"
RUN dotnet build "Planner-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Planner-Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Planner-Backend.dll"]
