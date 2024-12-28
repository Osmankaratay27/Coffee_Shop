using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CoffeeMenuManager : ICoffeeMenuService
	{
		ICoffeeMenuDal _coffeeMenuDal;

		public CoffeeMenuManager(ICoffeeMenuDal coffeeMenuDal)
		{
			_coffeeMenuDal = coffeeMenuDal;
		}

		public void AddCoffeeMenu(CoffeeMenu coffeeMenu)
		{
			_coffeeMenuDal.Add(coffeeMenu);
		}

		public void DeleteCoffeeMenu(CoffeeMenu coffeeMenu)
		{
			_coffeeMenuDal.Delete(coffeeMenu);
		}

		public List<CoffeeMenu> GetAllCoffeeMenu()
		{
			return _coffeeMenuDal.GetListAll();
		}

		public CoffeeMenu GetCoffeeMenuById(int id)
		{
			return _coffeeMenuDal.GetByID(id);
		}

		public void UpdateCoffeeMenu(CoffeeMenu coffeeMenu)
		{
			_coffeeMenuDal.Update(coffeeMenu);
		}
	}
}
