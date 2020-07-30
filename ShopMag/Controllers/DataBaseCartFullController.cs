using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

using Microsoft.AspNetCore.Mvc;
using ShopMag.Data;
using ShopMag.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Controllers
{
	[Route("api/[controller]")]
	public class DataBaseCartFullController: Controller
	{
		private readonly AppDBContent appDBContent;

		public DataBaseCartFullController(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		[HttpGet]
		public object Get(DataSourceLoadOptions loadOptions)
		{
			List<ShopCartItem> list = new List<ShopCartItem>();
			list = appDBContent.ShopCartItem.ToList();
			 


			return DataSourceLoader.Load(list, loadOptions);
		}
	}
}
