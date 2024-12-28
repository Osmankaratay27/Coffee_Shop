using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICoffeeMenuService
	{
		void AddCoffeeMenu(CoffeeMenu coffeeMenu);
		void DeleteCoffeeMenu(CoffeeMenu coffeeMenu);
		void UpdateCoffeeMenu(CoffeeMenu coffeeMenu);
		List<CoffeeMenu> GetAllCoffeeMenu();
		CoffeeMenu GetCoffeeMenuById(int id);
	}
}
