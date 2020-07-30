using ShopMag.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Data.interfaces
{
	public interface IAllCars
	{
		IEnumerable<Car> Cars { get; }  //получить весь список авто
		IEnumerable<Car> getFavCars { get; } //список любимых авто
		Car getOdjectCar(int carId); //получить тачку по id
	}
}
