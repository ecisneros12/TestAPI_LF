using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [JsonIgnore] // loops y errores con el JSON
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}


