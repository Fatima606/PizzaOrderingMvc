﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingMvc.Models;
using PizzaOrderingMvc.PizzaApp_DbContext;

namespace PizzaOrderingMvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly PizzaAppDbContext _pizzaLoading;
        private static int _totalPizzasOrdered = 0;
        public OrderController(PizzaAppDbContext pizzaLoading)
        {
            _pizzaLoading=pizzaLoading;
        }
        public IActionResult DisplayOrders()
        {
            _totalPizzasOrdered = 0;
            var orders = _pizzaLoading.Pizza.Include(p => p.Size).Include(p => p._base).ToList();
            var pizzaToppings = new Dictionary<Guid, List<string>>();
            foreach (var order in orders)
            {
                var toppings = _pizzaLoading.PizzaTopping
                    .Where(to => to.PizzaId == order.PizzaId)
                    .Select(to => to.Topping.ToppingName)
                    .ToList();

                pizzaToppings[order.PizzaId] = toppings;

                _totalPizzasOrdered++;

            }

            ViewBag.TotalPizzasOrdered = _totalPizzasOrdered;
            ViewBag.Pizzas = orders;
            ViewBag.PizzaToppings = pizzaToppings;


            return View();
        }
    }
}
