FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Establecer el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copiar el archivo csproj y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Instalar dotnet-ef
RUN dotnet tool install --global dotnet-ef --version 7.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copiar el resto del código fuente y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Generar la imagen final para la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app
COPY --from=build-env /app/out .
COPY Models /app/Models

# Exponer el puerto en el que la aplicación escucha
EXPOSE 80

# Iniciar la aplicación al iniciar el contenedor
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

ENTRYPOINT ["./entrypoint.sh"]