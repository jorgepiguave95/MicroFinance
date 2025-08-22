## Levantando el Proyecto con Docker

1. Clona el repositorio y navega a la raíz del proyecto.
2. Ejecuta el siguiente comando en la terminal:

   ```sh
   docker compose up --build
   ```

Esto construirá y levantará todos los microservicios y la base de datos definida en el archivo `docker-compose.yml`.

## Instalación de Entity Framework Core

Para agregar Entity Framework Core a un microservicio, ejecuta en la carpeta del proyecto correspondiente:

```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef
```

## Migraciones manuales con Entity Framework Core

Por defecto, las migraciones automáticas están deshabilitadas en los microservicios. Para aplicar cambios en la base de datos, debes ejecutar los siguientes comandos manualmente desde la carpeta del microservicio correspondiente:

```sh
# Crear una nueva migración (ajusta el nombre según el cambio)
dotnet ef migrations add NombreDeLaMigracion

# Aplicar las migraciones pendientes a la base de datos
dotnet ef database update
```

Si necesitas eliminar todas las migraciones y empezar de cero:

```sh
# Elimina la carpeta Migrations (opcional)
rm -r Migrations

# Crea una nueva migración inicial
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Instalación de Swagger

Para agregar Swagger a un microservicio, ejecuta en la carpeta del proyecto correspondiente:

```sh
dotnet add package Swashbuckle.AspNetCore
```

Luego, en el archivo `Program.cs` del microservicio, agrega lo siguiente:

```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
```
