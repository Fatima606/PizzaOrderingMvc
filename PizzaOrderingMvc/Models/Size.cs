using System.ComponentModel.DataAnnotations;

namespace PizzaOrderingMvc.Models
{
    public class Size
    {
        [Key]
        public Guid SizeId { get; set; }
        public string PizzaSize { get; set; }
    }
}
