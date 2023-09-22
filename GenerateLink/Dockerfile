FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# set container timezone to +7 PP
ENV TZ=Asia/Phnom_Penh
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GenerateLink/GenerateLink.csproj", "GenerateLink/"]
RUN dotnet restore "GenerateLink/GenerateLink.csproj"
COPY . .
WORKDIR "/src/GenerateLink"
RUN dotnet build "GenerateLink.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GenerateLink.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GenerateLink.dll"]

