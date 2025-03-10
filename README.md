# Prueba Técnica: API REST en .NET con MySQL

## Descripción

Este proyecto es una API REST desarrollada en .NET que se conecta a una base de datos MySQL. La API proporciona una capa de acceso a datos, permitiendo la interacción con MySQL de manera eficiente y estructurada.

## Tecnologías Utilizadas

- **.NET** (C#)
- **ASP.NET Core**
- **MySQL**
- **Entity Framework Core**

## Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalados los siguientes componentes:

- .NET SDK 6.0 o superior
- MySQL Server
- MySQL Workbench (opcional, para administrar la base de datos)
- Visual Studio
- Postman o similar para probar la API

## Configuración

1. Clona este repositorio:
   ```bash
   git clone https://github.com/karinaSierra/RestAPI-NetCore-MySQL.git
   cd RestAPI-NetCore-MySQL
   ```
2. Configura la conexión a MySQL en `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
     "MySQLConnection": "server=localhost;port=3306;database=entidades;uid=root;password=k0173_"
     }
   }
   ```
3. Aplica las migraciones de Entity Framework:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

## Ejecución del Proyecto

Para ejecutar la API, usa el siguiente comando:

```bash
dotnet run
```

La API estará disponible cuando la corres en local en `https://localhost:7222/swagger/index.html`

## Base de Datos
Se ha generado una base de datos llamada `entidades`, la cual contiene dos tablas:
- **municipio**
- **departamento**

## Endpoints

### Departamento
- **GET /api/departament/GetAllDepart**: Obtiene todos los departamentos.
- **GET /api/departament/GetDepartById/{id}**: Obtiene un departamento por ID.
- **POST /api/departament/CreateDepart**: Crea un nuevo departamento.
- **PUT /api/departament/UpdateDepart/{id}**: Actualiza un departamento existente.
- **DELETE /api/departament/DeleteDepart/{id}**: Elimina un departamento.

### Municipio
- **GET /api/municipality/GetAllMunici**: Obtiene todos los municipios.
- **GET /api/municipality/GetMuniciById/{id}**: Obtiene un municipio por ID.
- **POST /api/municipality/CreateMunici**: Crea un nuevo municipio.
- **PUT /api/municipality/UpdateMunici/{id}**: Actualiza un municipio existente.
- **DELETE /api/municipality/DeleteMunici/{id}**: Elimina un municipio.

## Pruebas
Puedes probar la API con Postman o swagger
```

## Licencia
Este proyecto se distribuye bajo la licencia MIT.

---
¡Gracias! 🚀