using Microsoft.AspNetCore.Mvc;
using ShopMag.Data.interfaces;
using ShopMag.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Controllers
{
	public class OrderController: Controller
	{
		private readonly IAllOrders allOrders;
		private readonly ShopCart shopCart;

		public OrderController(IAllOrders allOrders, ShopCart shopCart)
		{
			this.allOrders = allOrders;
			this.shopCart = shopCart;
		}

		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			shopCart.listShopItems = shopCart.getShopItems();

			if(shopCart.listShopItems.Count == 0)
			{
				ModelState.AddModelError("", "У вас должны быть товары");
			}

			if (ModelState.IsValid)
			{
				allOrders.createOrder(order);
				return RedirectToAction("Complete");
			}
			return View();
		}

		public IActionResult Complete()
		{
			ViewBag.Message = "Заказ успешно обработан";
			return View();
		}
	}
}
