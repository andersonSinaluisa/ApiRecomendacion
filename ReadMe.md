## API DE RECOMENDACIÓN BASADO EN CONTENIDO

Este proyecto es una Web API desarrollada en C# utilizando el framework .NET Core. La API es capaz de manejar solicitudes HTTP y proporcionar una respuesta en formato JSON.

Características
Implementa autenticación JWT para proteger los endpoints.
Utiliza Entity Framework Core como ORM para acceder a una base de datos PostgreSQL.
Implementa Swagger como herramienta de documentación de la API.
Incluye pruebas unitarias para garantizar el correcto funcionamiento de la API.
Requisitos
.NET Core SDK 3.1 o superior.
Una instancia de PostgreSQL para almacenar los datos de la aplicación.
Configuración
Antes de ejecutar la aplicación, se debe configurar la conexión a la base de datos en el archivo appsettings.json, especificando el nombre del servidor, puerto, nombre de la base de datos, usuario y contraseña:

`
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=nombre_servidor;Port=puerto;Database=nombre_db;Username=usuario;Password=contraseña"
  },
  ...
}
`
También es posible configurar la duración del token JWT y la clave secreta utilizada para firmar los tokens:

`
{

    "SecretKey": "clave_secreta",
     "SecretJwt": "clave_jwt"

  ...
}`
