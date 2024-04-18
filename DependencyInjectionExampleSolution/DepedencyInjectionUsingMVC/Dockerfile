# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# RUN mkdir /app
# # Create a non-root user
# RUN groupadd -g 1001 myuser && \
#     useradd -r -u 1001 -g myuser myuser
    
# RUN echo "Setting permission"
# # Set permissions for the application directory
# RUN chown -R myuser:myuser /app

# # Set the working directory
# WORKDIR /app

# # Copy your application files
# ARG artifact=dotnet_artifacts/*
# COPY ${artifact} .

# # Expose port 80
# EXPOSE 5000

# # Switch to the non-root user
# USER myuser

# # Set the entry point for your application
# ENTRYPOINT ["dotnet", "DependencyInjectionUsingMVC.dll"]
 # Testing the functionality

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY  . . 
RUN dotnet publish "DepedencyInjectionUsingMVC.csproj" -c release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
# RUN useradd -u 8765 non-root && chown -R non-root /tmp
RUN adduser --disabled-password --gecos '' non-root && \
    chown -R non-root /app
USER non-root
EXPOSE 5000
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DependencyInjectionUsingMVC.dll"]
