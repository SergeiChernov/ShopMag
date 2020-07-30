using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Data.Models
{
	public class ShopCart
	{
		private readonly AppDBContent appDBContent;

		public ShopCart(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		public string ShopCartId { get; set; }

		public List<ShopCartItem> listShopItems { get; set; }
		 
		public static ShopCart GetCart(IServiceProvider services)
		 {
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //объект для работы с сессиями
			var context = services.GetService<AppDBContent>();
			string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();            //id корзины

			session.SetString("CartId", shopCartId);

			return new ShopCart(context) { ShopCartId = shopCartId };
		 }

		public void AddToCart(Car car)
		{

			appDBContent.ShopCartItem.Add(new ShopCartItem
			{
				ShopCartId = ShopCartId,
				car = car,
				price = car.price
				
			});
			
			appDBContent.SaveChanges();
		}
		//
		public void RemoveFromCart(Car car)
		{
			ShopCartItem item = appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(i => i.car).First();
			appDBContent.ShopCartItem.Remove(item);

			appDBContent.SaveChanges();
		}

		
		public void RemoveAllCart()
		{
			List<ShopCartItem> listShopItems = new List<ShopCartItem>();
			listShopItems = appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).ToList();
			appDBContent.ShopCartItem.RemoveRange(listShopItems);

			appDBContent.SaveChanges();
		}


		public List<ShopCartItem> getShopItems()
		{
			return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
		}

		 


	}
}