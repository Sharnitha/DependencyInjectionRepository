FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ARG artifact=dotnet_artifacts/*
COPY ${artifact} .
EXPOSE 80
ENTRYPOINT ["dotnet", "DependencyInjectionUsingMVC.dll"]
