#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aquaculture.Api/Aquaculture.Api.csproj", "Aquaculture.Api/"]
COPY ["Aquaculture.Contracts/Aquaculture.Contracts.csproj", "Aquaculture.Contracts/"]
COPY ["Aquaculture.Infrastructure/Aquaculture.Infrastructure.csproj", "Aquaculture.Infrastructure/"]
COPY ["Aquaculture.Application/Aquaculture.Application.csproj", "Aquaculture.Application/"]
COPY ["Aquaculture.Domain/Aquaculture.Domain.csproj", "Aquaculture.Domain/"]
RUN dotnet restore "Aquaculture.Api/Aquaculture.Api.csproj"
COPY . .
WORKDIR "/src/Aquaculture.Api"
RUN dotnet build "Aquaculture.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aquaculture.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aquaculture.Api.dll"]