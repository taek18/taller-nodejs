ToDoApp – Aplicación de Lista de Tareas con ASP.NET Core MVC + Identity  
Este proyecto corresponde al desarrollo solicitado para el taller de ASP.NET Core, implementando una aplicación web completa que utiliza MVC, Entity Framework Core, SQLite y ASP.NET Core Identity para autenticar usuarios y permitirles gestionar sus listas personales de tareas.  

Características principales
   * Construida con ASP.NET Core MVC 7.
   * Sistema de autenticación y registro de usuarios con Identity.
   * Cada usuario gestiona su propia lista de tareas.
   * Operaciones CRUD completas:
      - Crear tareas
      - Mostrar lista de tareas
      - Editar tareas
      - Eliminar tareas
   * Campos de tarea:
      - Título
      - Descripción
      - Fecha de creación
      - Estado (Pendiente / Completada)
      - Usuario propietario
   * Diseño responsivo mediante Bootstrap (incluido por default en ASP.NET Core).
   * Base de datos SQLite generada por migraciones.

Estructura del proyecto  
ToDoApp/  
│  
├── Controllers/  
│   └── TodoController.cs        # Lógica de manejo de tareas  
│  
├── Models/  
│   └── TodoItem.cs              # Modelo de datos  
│  
├── Data/  
│   └── ApplicationDbContext.cs  # Configuración EF Core + Identity  
│  
├── Views/  
│   ├── Todo/                    # Vistas CRUD  
│   └── Shared/                  # Layouts y parciales  
│  
├── Areas/  
│   └── Identity/                # Páginas generadas para login/registro  
│  
├── wwwroot/                     # Recursos estáticos (CSS, JS, imágenes)  
│  
├── appsettings.json             # Configuración y cadena de conexión  
│  
└── README.md  

Tecnologías utilizadas  
   * ASP.NET Core 7.0
   * Entity Framework Core 7
   * SQLite
   * ASP.NET Core Identity
   * Bootstrap 5
   * C# 11


Instrucciones para ejecutar el proyecto  
1. Clonar el repositorio  
   git clone https://github.com/tu-usuario/tu-repo.git  
   cd tu-repo  
2. Configurar la base de datos  
Revisar la cadena de conexión en appsettings.json (ya está configurada para SQLite):  
   "ConnectionStrings": {  
     "DefaultConnection": "Data Source=app.db"  
   }  
3. Ejecutar migraciones  
   dotnet ef database update  
Esto creará app.db.  
4. Ejecutar la aplicación  
   dotnet run  
Acceder en:  
   http://localhost:5000  

Licencia  
Este proyecto es de uso académico y puede distribuirse bajo la licencia MIT.

Autor  
Desarrollado por Kim Mtz como parte del taller de ASP.NET Core.
