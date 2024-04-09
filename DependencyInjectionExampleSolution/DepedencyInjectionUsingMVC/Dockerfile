# FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
# WORKDIR /src
# COPY . /src
# RUN dotnet publish "DepedencyInjectionUsingMVC.csproj" -c release -o /tmp/publish

# FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
# WORKDIR /tmp
# RUN useradd -u 8765 non-root && chown -R non-root /tmp
# USER non-root
# EXPOSE 80
# COPY --from=build /tmp/publish .
# ENTRYPOINT ["dotnet", "DependencyInjectionUsingMVC.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ARG artifact=dotnet_artifacts/*
COPY ${artifact} .
EXPOSE 80
ENTRYPOINT ["dotnet", "DependencyInjectionUsingMVC.dll"]
