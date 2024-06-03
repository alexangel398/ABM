using System.ComponentModel.DataAnnotations;

namespace ABMProveedores.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        
    }
}
