using Microsoft.AspNetCore.Mvc;
using PizzaOrderingMvc.DTO;
using PizzaOrderingMvc.Models;
using PizzaOrderingMvc.PizzaApp_DbContext;

namespace PizzaOrderingMvc.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaAppDbContext _pizzaLoading;
        public PizzaController(PizzaAppDbContext pizzaLoading)
        {
            _pizzaLoading = pizzaLoading;
        }
        [HttpGet]
        public IActionResult CreatePizza()
        {
            ViewBag.bases = _pizzaLoading.Base.ToList();
            ViewBag.toppings = _pizzaLoading.Toppings.ToList();
            ViewBag.sizes = _pizzaLoading.Size.ToList();
            var pizzaDetails = new PizzaViewModel();

            return View(pizzaDetails);
        }
        [HttpPost]
        public IActionResult CreatePizza(PizzaViewModel model)
        {

            var pizza = new Pizza
            {
                BaseId = model.BaseId,
                SizeId = model.SizeId
            };
            _pizzaLoading.Pizza.Add(pizza);
            _pizzaLoading.SaveChanges();
            foreach (var toppingId in model.ToppingIds)
            {
                var toppingsOrder = new PizzaTopping
                {
                    PizzaId = pizza.PizzaId,
                    ToppingId = toppingId
                };
                _pizzaLoading.PizzaTopping.Add(toppingsOrder);
                _pizzaLoading.SaveChanges();
            }
            var order = new Order
            {
                PizzaId = pizza.PizzaId
            };
            _pizzaLoading.Order.Add(order);
            _pizzaLoading.SaveChanges();
            return RedirectToAction("CreatePizza");
        }
    }
}
