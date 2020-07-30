using Microsoft.EntityFrameworkCore;
using ShopMag.Data.interfaces;
using ShopMag.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Data.Repository
{
	public class CarRepository : IAllCars
	{
		private readonly AppDBContent appDBContent;

		public CarRepository(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}


		public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

		public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.isFavourite).Include(c => c.Category);

		public Car getOdjectCar(int carId) => appDBContent.Car.FirstOrDefault(p=>p.id == carId);
	}
}
