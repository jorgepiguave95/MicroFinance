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

Para crear una migración y actualizar la base de datos:

```sh
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
