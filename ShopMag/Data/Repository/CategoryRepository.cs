using ShopMag.Data.interfaces;
using ShopMag.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMag.Data.Repository
{
	public class CategoryRepository : ICarsCategory
	{
		private readonly AppDBContent appDBContent;
		
		public CategoryRepository(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}


		public IEnumerable<Category> AllCategories => appDBContent.Category;
	}
}
