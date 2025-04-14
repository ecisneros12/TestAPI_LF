using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos(
        [FromQuery] string? nombre,
        [FromQuery] string? descripcion,
        [FromQuery] decimal? precioMin,
        [FromQuery] decimal? precioMax)
           {
               var query = _context.Productos
                   .Include(p => p.Categoria)
                   .AsQueryable();
        
               if (!string.IsNullOrWhiteSpace(nombre))
                   query = query.Where(p => p.Nombre.Contains(nombre));
        
               if (!string.IsNullOrWhiteSpace(descripcion))
                   query = query.Where(p => p.Descripcion.Contains(descripcion));
        
               if (precioMin.HasValue)
                   query = query.Where(p => p.Precio >= precioMin.Value);
        
               if (precioMax.HasValue)
                   query = query.Where(p => p.Precio <= precioMax.Value);
        
               return await query.ToListAsync();
        }


        // GET: api/ProductosApi
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // POST: api/ProductosApi
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            // Verificar si la categoría existe
            var categoria = await _context.Categorias.FindAsync(producto.CategoriaId);
            if (categoria == null)
            {
                return BadRequest(new { message = "La categoría no existe." });
            }

            // No asignamos el Id manualmente; SQL Server lo genera automáticamente

            // Agregar el producto a la base de datos
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            // Recargar la categoría del producto para que se devuelva correctamente
            await _context.Entry(producto).Reference(p => p.Categoria).LoadAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }





        // PUT: api/ProductosApi
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ProductosApi
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
