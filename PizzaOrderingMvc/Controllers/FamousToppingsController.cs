using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingMvc.Models;
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
                var ConfirmedOrders = _pizzaLoading.Pizza.Include(co => co.Size).Include(co => co._base).ToList();
                var pizzaToppings = new Dictionary<Guid, List<string>>();
                foreach (var order in ConfirmedOrders)
                {
                    var toppings = _pizzaLoading.PizzaTopping
                        .Where(to => to.PizzaId == order.PizzaId)
                        .Select(to => to.Topping.ToppingName)
                        .ToList();

                    pizzaToppings[order.PizzaId] = toppings;

                }

                TempData["PizzaToppings"] = pizzaToppings;

                return View(ConfirmedOrders);
            }
            catch (Exception e)
            {
                return View("Home", "Index");
            }
        }
    }
}
