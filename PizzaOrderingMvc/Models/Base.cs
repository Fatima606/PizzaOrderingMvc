using System.ComponentModel.DataAnnotations;

namespace PizzaOrderingMvc.Models
{
    public class Base
    {
        [Key]
        public Guid baseId { get; set; }
        public string BaseName { get; set; }
    }
}
