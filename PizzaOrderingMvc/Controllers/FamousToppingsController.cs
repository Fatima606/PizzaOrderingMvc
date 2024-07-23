using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingMvc.PizzaApp_DbContext;

namespace PizzaOrderingMvc.Controllers
{
    public class FamousToppingsController : Controller
    {
        private readonly PizzaAppDbContext _pizzaLoading;
        public FamousToppingsController(PizzaAppDbContext pizzaLoading)
        {
            _pizzaLoading = pizzaLoading;
        }
        public IActionResult FamousToppings()
        {
            try
            {
                var ConfirmedOrders = _pizzaLoading.Order
                    .Include(c => c.Pizza)
                    .ThenInclude(p => p.Size)
                    .Include(c => c.Pizza)
                    .ThenInclude(p => p._base)
                    .ToList();
                return View(ConfirmedOrders);
            }
            catch (Exception e)
            {
                return View("Home", "Index");
            }
        }
    }
}
