using Microsoft.AspNetCore.Mvc;
using ShopMag.Data.interfaces;
using ShopMag.Data.Models;
using ShopMag.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Controllers
{
	public class CarsController : Controller
	{
		private readonly IAllCars _allCars;
		//private readonly ICarsCategory _allCategories;

		public CarsController(IAllCars iAllCars)
		{
			_allCars = iAllCars;
			//_allCategories = iCarsCat;
		}

		[Route("Cars/List")]
		[Route("Cars/List/{category}")]
		public ViewResult List(string category)
		{
			string _category = category;
			IEnumerable<Car> cars = null;
			string currCategory = "";
			if (string.IsNullOrEmpty(category))
			{
				cars = _allCars.Cars.OrderBy(i => i.id);
			}
			else
			{
				if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
				{
					cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
					currCategory = "Электромобили";
				}
				else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
				{
					cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
					currCategory = "Классические автомобили";
				}

				
			}

			var carObj = new CarsListViewModel()
			{
				allCars = cars,
				currCategory = currCategory
			};

			return View(carObj);

		}

	}
}
