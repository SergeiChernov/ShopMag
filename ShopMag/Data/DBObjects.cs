using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopMag.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Data
{
	public class DBObjects
	{
		public static void Initial(AppDBContent content)
		{
		

			if (!content.Category.Any())
			{
				content.Category.AddRange(Categories.Select(c => c.Value));
			}
			if (!content.Car.Any())
			{
				content.AddRange(
					new Car
					{
						name = "Tesla",
						shortDesc = "Быстрый",
						longDesc = "Тихий и спокойный",
						img = "/img/1.jpg",
						price = 45000,
						isFavourite = false,
						available = false,
						Category = Categories["Электромобили"]
					},
					new Car
					{
						name = "Tesla",
						shortDesc = "",
						longDesc = "Тихий и спокойный ",
						img = "/img/2.jpg",
						price = 45000,
						isFavourite = true,
						available = true,
						Category = Categories["Электромобили"]
					},
					new Car
					{
						name = "Tesla",
						shortDesc = "",
						longDesc = "",
						img = "/img/3.jpg",
						price = 45000,
						isFavourite = true,
						available = true,
						Category = Categories["Электромобили"]
					},
					new Car
					{
						name = "Tesla",
						shortDesc = "",
						longDesc = "",
						img = "/img/4.jpg",
						price = 45000,
						isFavourite = true,
						available = true,
						Category = Categories["Электромобили"]
					},
					new Car
					{
						name = "Tesla",
						shortDesc = "",
						longDesc = "",
						img = "/img/5.jpg",
						price = 45000,
						isFavourite = true,
						available = true,
						Category = Categories["Классические автомобили"]
					},
					new Car
					{
						name = "Tesla",
						shortDesc = "",
						longDesc = "",
						img = "/img/6.jpg",
						price = 45000,
						isFavourite = true,
						available = true,
						Category = Categories["Классические автомобили"]
					},
					new Car
					{
						name = "Tesla",
						shortDesc = "",
						longDesc = "",
						img = "/img/7.jpg",
						price = 45000,
						isFavourite = true,
						available = true,
						Category = Categories["Классические автомобили"]
					},
					new Car
					{
						name = "Tesla",
						shortDesc = "",
						longDesc = "",
						img = "/img/5.jpg",
						price = 45000,
						isFavourite = true,
						available = true,
						Category = Categories["Классические автомобили"]
					}, new Car
					{
						name = "Tesla",
						shortDesc = "",
						longDesc = "",
						img = "/img/5.jpg",
						price = 45000,
						isFavourite = true,
						available = true,
						Category = Categories["Классические автомобили"]
					}
				);
			}
			content.SaveChanges();
		}

		public static Dictionary<string, Category> category;
		public static Dictionary<string, Category> Categories {
			get {
				if (category == null)
				{
					var list = new Category[]
					{
						new Category { categoryName = "Электромобили", desc = "Современный вид транспорта"},
					    new Category { categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего сгорания"}
					};

					category = new Dictionary<string, Category>();
					foreach(Category el in list)
					{
						category.Add(el.categoryName, el);
					}
				}
				return category;
		    }
		}
	}
}
