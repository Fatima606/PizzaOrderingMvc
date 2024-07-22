using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderingMvc.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [ForeignKey("Pizza")]
        public Guid PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
