# Usa una imagen de Node.js como base
FROM node:14 as build

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia los archivos de la aplicación al contenedor
COPY package*.json ./

# Instala las dependencias de la aplicación
RUN npm install

# Copia el resto de los archivos de la aplicación al contenedor
COPY . .

# Construye la aplicación de Angular
RUN npm run build --prod

# Utiliza una imagen más pequeña y eficiente de Nginx para el despliegue de la aplicación
FROM nginx:alpine

# Copia los archivos de la construcción de la aplicación a la ubicación correcta en Nginx
COPY --from=build /app/dist/<nombre_de_tu_app> /usr/share/nginx/html

# Expone el puerto 80 para que se pueda acceder a la aplicación
EXPOSE 80

# Inicia Nginx cuando se ejecute el contenedor
CMD ["nginx", "-g", "daemon off;"]
