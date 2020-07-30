using Microsoft.AspNetCore.Mvc;
using ShopMag.Data;
using ShopMag.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Controllers
{
	public class DataBaseCartController: Controller
	{

		public ViewResult ViewM()
		{
		   return View();
		}
	}
}
