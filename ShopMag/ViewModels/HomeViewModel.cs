using ShopMag.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Car> favCars { get; set; }
	}
}
