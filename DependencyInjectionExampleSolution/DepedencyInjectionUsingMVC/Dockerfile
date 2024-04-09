FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# Create a non-root user
RUN groupadd -g 1001 myuser && \
    useradd -r -u 1001 -g myuser myuser

# Set permissions for the application directory
RUN chown -R myuser:myuser /app

# Set the working directory
WORKDIR /app

# Copy your application files
ARG artifact=dotnet_artifacts/*
COPY ${artifact} .

# Expose port 80
EXPOSE 80

# Switch to the non-root user
USER myuser

# Set the entry point for your application
ENTRYPOINT ["dotnet", "Depend.dll"]
