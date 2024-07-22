using System.ComponentModel.DataAnnotations;

namespace PizzaOrderingMvc.Models
{
    public class Toppings
    {
        [Key]
        public Guid ToppingId { get; set; }
        public string ToppingName { get; set; }
    }
}
