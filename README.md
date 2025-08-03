# Sales Date Prediction API

Este proyecto es el backend de la aplicación "Sales Date Prediction", desarrollado en .NET 8. Proporciona una API RESTful para gestionar clientes, órdenes, empleados, transportistas y productos, además de la funcionalidad principal de predicción de fechas de próximas órdenes.

## 🚀 Características

- **Framework**: .NET 8
- **ORM**: Entity Framework Core 8
- **Base de Datos**: SQL Server 
- **Documentación**: Swagger/OpenAPI
- **Arquitectura**: Clean Architecture DDD (Domain-Driven Design)
- **Testing**: xUnit

## 📋 Prerrequisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/)

## 🛠️ Instalación

### 1. Clonar el repositorio
```bash
git clone https://github.com/fernando-ibz/sales-date-prediction-back.git
cd sales-date-prediction-back
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Configurar la base de datos
- Ejecutar el script `DBSetup.sql` en su instancia de SQL Server
  Disponible en le ruta del repositorio [\Sales.Infrastructure\Scripts\DBSetup.sql](https://github.com/fernando-ibz/sales-date-prediction-back/blob/3d0f19141900a85193827af1354885e8c02ad620/Sales.Infrastructure/Scripts/DBSetup.sql)

- Actualiza la cadena de conexión en `appsettings.json`:
  ```json
  {
    "ConnectionStrings": {
      "StoreDBConnection": "Server=(SQLEXPRESS);Database=StoreSample;Trusted_Connection=True;TrustServerCertificate=True"
    }
  }
  ```
- Ejecutar el script "usp_GetNextOrderPrediction.sql"
  Disponible en le ruta del repositorio [\Sales.Infrastructure\Scripts\usp_GetNextOrderPrediction.sql](https://github.com/fernando-ibz/sales-date-prediction-back/blob/3d0f19141900a85193827af1354885e8c02ad620/Sales.Infrastructure/Scripts/usp_GetNextOrderPrediction.sql)

### 4. Ejecutar la aplicación
```bash
dotnet run --project Sales.API
```
La API estará disponible en `https://localhost:7017` y `http://localhost:5099`.

## 🏗️ Arquitectura

El proyecto sigue los principios de Clean Architecture:
```
SalesDatePrediction
├──Sales.API                  # Capa de Presentación - Controladores REST y configuración HTTP
│  ├── Controllers            # Controladores que exponen endpoints de la API
│  └── Program.cs             # Punto de entrada y configuración de la aplicación
├──Sales.Application          # Capa de Aplicación - Lógica de negocio y casos de uso
│  ├── Services               # Servicios que orquestan operaciones de dominio
├──Sales.Domain               # Capa de Dominio - Entidades de negocio y contratos
│  ├── DTOs                   # Data Transfer Objects para comunicación entre capas
│  ├── Entities               # Entidades del dominio que representan conceptos de negocio
│  ├── Interfaces             # Contratos e interfaces del dominio
├──Sales.Infrastructure       # Capa de Infraestructura - Acceso a datos y servicios externos
│  ├── Configurations         # Configuraciones de Entity Framework y mapeos Fluen API
│  ├── Data                   # Contexto de base de datos
│  ├── Repositories           # Implementaciones concretas de repositorios
├──Sales.Tests                # Capa de Pruebas - Testing automatizado
```

### Patrones Implementados

- **Repository Pattern**: Abstracción del acceso a datos con un repositorio generico con uso de tipos ligado a entidades
- **Fluent API**: Legibilidad y fácil depuración de modelos de datos
- **CQRS**: Separación de comandos y consultas con restricción de dóminio
- **Dependency Injection**: Uso de interfaces para registrar y resolver las dependencias.
- **Data Transfer Object (DTO)**: Transporte de datos y baja exposición de las entidades de negocio

## 📊 Modelo de Datos
<img width="1072" height="748" alt="image" src="https://github.com/user-attachments/assets/58558d49-09bf-49c7-b625-9be44fca8e18" />

### Diagrama

## 🔗 Endpoints Principales

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/Customers` | Obtiene todos los clientes |
| POST | `/api/Customers` | Crea un nuevo cliente |
| GET | `/api/Customers/{id}` | Obtiene un cliente específico por ID |
| PUT | `/api/Customers/{id}` | Actualiza un cliente específico por ID |
| DELETE | `/api/Customers/{id}` | Elimina un cliente específico por ID |
| GET | `/api/Customers/CustomerName` | Busca clientes por nombre |
| GET | `/api/Employees` | Obtiene todos los empleados |
| POST | `/api/Employees` | Crea un nuevo empleado |
| GET | `/api/Employees/{id}` | Obtiene un empleado específico por ID |
| PUT | `/api/Employees/{id}` | Actualiza un empleado específico por ID |
| DELETE | `/api/Employees/{id}` | Elimina un empleado específico por ID |
| GET | `/api/Orders` | Obtiene todas las órdenes |
| POST | `/api/Orders` | Crea una nueva orden |
| GET | `/api/Orders/{id}` | Obtiene una orden específica por ID |
| PUT | `/api/Orders/{id}` | Actualiza una orden específica por ID |
| DELETE | `/api/Orders/{id}` | Elimina una orden específica por ID |
| GET | `/api/Orders/CustomerId/{customeId}` | Obtiene órdenes por ID de cliente |
| GET | `/api/Products` | Obtiene todos los productos |
| POST | `/api/Products` | Crea un nuevo producto |
| GET | `/api/Products/{id}` | Obtiene un producto específico por ID |
| PUT | `/api/Products/{id}` | Actualiza un producto específico por ID |
| DELETE | `/api/Products/{id}` | Elimina un producto específico por ID |
| GET | `/api/Shippers` | Obtiene todos los transportistas |
| POST | `/api/Shippers` | Crea un nuevo transportista |
| GET | `/api/Shippers/{id}` | Obtiene un transportista específico por ID |
| PUT | `/api/Shippers/{id}` | Actualiza un transportista específico por ID |
| DELETE | `/api/Shippers/{id}` | Elimina un transportista específico por ID |

## 📝 Ejemplos de Uso

### Crear un Producto

```bash
curl -X 'POST' \
  'https://localhost:7017/api/Orders' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "custId": 72,
  "empId": 3,
  "orderDate": "2025-08-03T04:37:35.279Z",
  "requiredDate": "2025-08-03T04:37:35.279Z",
  "shippedDate": "2025-08-03T04:37:35.279Z",
  "shipperId": 2,
  "freight": 1,
  "shipName": "test",
  "shipAddress": "test",
  "shipCity": "test",
  "shipRegion": "test",
  "shipPostalCode": "test",
  "shipCountry": "test",
  "orderDetail": {
    "productId": 16,
    "unitPrice": 18,
    "qty": 10,
    "discount": 0
  }
}'
```

### Respuesta
```json
{
  "orderId": 11087,
  "requiredDate": "2025-08-03T04:37:35.279Z",
  "shippedDate": "2025-08-03T04:37:35.279Z",
  "shipName": "test",
  "shipAddress": "test",
  "shipperId": 2,
  "shipCity": "test"
}
```

## 🧪 Testing

### Ejecutar todas las pruebas
```bash
dotnet test
```

## 🔧 Configuración

### Variables de Entorno

| Variable | Descripción | Valor por Defecto |
|----------|-------------|-------------------|
| `ASPNETCORE_ENVIRONMENT` | Entorno de ejecución | `Development` |

### appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ProdAllowedHost": ".fernandoibz.com",
  "ConnectionStrings": {
    "StoreDBConnection": "Server=NANO\\NANOSQLEXPRESS;Database=StoreSample;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

## 🚀 Despliegue

### Docker

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sales.API/Sales.API.csproj", "Sales.API/"]
RUN dotnet restore "./Sales.API/Sales.API.csproj"
COPY . .
WORKDIR "/src/Sales.API"
RUN dotnet build "./Sales.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Sales.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.API.dll"]
```

### Comandos Docker

```bash
# Construir imagen
docker build -t sales-api .

# Ejecutar contenedor
docker run -d -p 8080:80 --name sales-api sales-api
```

## 📚 Documentación API

Una vez que la aplicación esté ejecutándose `localmente`, puedes acceder a la documentación interactiva de Swagger en:

- **Swagger UI**: `https://localhost:7017/swagger/index.html`

### Estándares de Código

- Seguir las convenciones de C# y .NET
- Seguir principios SOLID


## 👥 Autores

- **Fernando Ibáñez** - *Desarrollo inicial* - [fernando-ibz](https://github.com/fernando-ibz)

## 🙏 Agradecimientos

- Entity Framework Core Team
- .NET Community
- Swagger/OpenAPI Initiative

## 📞 Soporte

¿Tienes preguntas o problemas? 
- 📧 Email: fernando.ibz.g@gmail.com

---

⭐ ¡No olvides dar una estrella al proyecto si te ha sido útil!
