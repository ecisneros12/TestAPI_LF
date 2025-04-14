# TestAPI_LF
Prueba creacion de API rest backend - Frontend, tecnologia y herramientas usadas.
📦 CRUD API + Web App con .NET Core, EF y Bootstrap
Este proyecto implementa una API RESTful con funcionalidades completas para registrar, actualizar, eliminar y obtener información desde el servidor. Además, incluye una aplicación web que consume esta API para administrar datos desde el navegador.

🗂 Estructura del Proyecto
Backend (.NET Core + EF Core)
API RESTful para gestionar entidades relacionadas.
Base de datos con al menos 2 tablas relacionadas (Categoria, Producto).
Uso de Entity Framework Core para el acceso a datos.
Implementación de operaciones CRUD completas.
Frontend (HTML + Bootstrap + JavaScript)
Interfaz visual con Bootstrap 3+.
Consumo de la API vía peticiones asíncronas (fetch o jQuery AJAX).
Filtros para buscar productos por ID, nombre, descripción, etc.
Estilo responsivo y amigable al usuario.

🧱 Modelo de Datos
Categoría
public class Categoria
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [JsonIgnore] // loops y errores con el JSON
    public List<Producto> Productos { get; set; } = new List<Producto>();
}
Producto
public class Producto
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }  //Puede ser requerido o no
}

🚀 Endpoints Principales
Método	Ruta	Descripción
GET	/api/productos	Obtener todos los productos
GET	/api/productos/{id}	Obtener producto por ID
POST	/api/productos	Crear un nuevo producto
PUT	/api/productos/{id}	Actualizar un producto
DELETE	/api/productos/{id}	Eliminar un producto
GET	/api/categorias	Listar categorías disponibles

🌐 Aplicación Web
  Pagina principal con listado de productos.
  Filtros por nombre, descripcion y monto
  Todos los datos se cargan o actualizan mediante peticiones asincrónicas (fetch o $.ajax).
  Uso de Bootstrap 5.3

⚙️ Instrucciones de Uso:
1- Clonar repositorio:
git clone https://github.com/nombre-proyecto.git
cd nombre-proyecto
2. Configurar la cadena de conexión en appsettings.json.
3. Ejecutar migraciones y crear la base de datos:
dotnet ef migrations add InitialCreate
dotnet ef database update
4. Ejecutar el servidor:
dotnet run
Abrir desde la interfaz web en  http://localhost:5179/crear-producto.html o desde el proyecto cliente.

Extras:
Prueba de funcionalidad:
![2](https://github.com/user-attachments/assets/5321c2a8-139d-44b8-bc7b-16f2d0e3589f)
![3](https://github.com/user-attachments/assets/068201c9-a3eb-41df-aae6-b9b3a74ca181)
![4](https://github.com/user-attachments/assets/5861c37e-44f3-46a1-9b97-1e96492bab5b)
![5](https://github.com/user-attachments/assets/6fbe4b8f-822b-447e-baba-3c1090649122)
![6](https://github.com/user-attachments/assets/3143b30e-3d5c-48f3-9bf8-9f0681cd1f18)
![7](https://github.com/user-attachments/assets/15c0877c-16d8-40df-b7fc-56f6912a61fe)
![8](https://github.com/user-attachments/assets/d6d046b3-467d-4578-b674-202249a72b55)
![9](https://github.com/user-attachments/assets/525ac639-63ec-47d0-994b-d09c88473de2)
![10](https://github.com/user-attachments/assets/5d91325f-5fbd-4c50-afb3-60d50f2432e9)
![11](https://github.com/user-attachments/assets/faf06a3b-be91-419e-afbc-e140b33eda16)
![12](https://github.com/user-attachments/assets/d44a11d9-48c9-4389-98a1-92cce3f60793)
![13](https://github.com/user-attachments/assets/e3b97538-0e06-4d45-9eb6-0ada8107529e)
![14](https://github.com/user-attachments/assets/9b8b5881-0bf8-40b0-9b87-e185e9811ae7)
![1](https://github.com/user-attachments/assets/8cfc4b7a-9c33-4e35-9bd6-2f2835090f88)

