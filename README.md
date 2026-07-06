# CrediAuto Backend

API REST del simulador de crédito vehicular Compra Inteligente.

Repositorio: https://github.com/FInanzas-Grupo/finanzas-backend

## Stack

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core (Npgsql)
- PostgreSQL
- JWT (autenticación)
- Swagger / OpenAPI

## Estructura del proyecto

- `Cars`
- `Clients`
- `IAM`
- `Profiles`
- `Schedules`
- `Shared`
- `Simulations`

## Requisitos

- .NET 9 SDK
- PostgreSQL

## Variables de entorno / Configuración

Configurar en `appsettings.json` o `appsettings.Development.json`:

| Variable / Key                          | Descripción                                  |
|------------------------------------------|-----------------------------------------------|
| ConnectionStrings:DefaultConnection      | Cadena de conexión a PostgreSQL               |
| Jwt:Secret (o similar)                   | Clave secreta para firmar tokens JWT          |

## Instalación

```bash
dotnet restore
dotnet build
dotnet run --project CrediAuto.API
```

## Deploy en Render

El backend y la base de datos PostgreSQL se despliegan en Render.

Configurar la variable de entorno de conexión (`ConnectionStrings__DefaultConnection`) apuntando a la instancia de PostgreSQL provisionada en Render.
