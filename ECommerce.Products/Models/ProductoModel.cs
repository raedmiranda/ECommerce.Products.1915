using System.ComponentModel.DataAnnotations;

namespace ECommerce.Products.Models
{
    public class ProductoModel
    {
        [Display(Name="Código")]
        public int Id { get; set; }
        [Display(Name="Nombre de producto"), Required]
        public string Nombre { get; set; }
    }
}
