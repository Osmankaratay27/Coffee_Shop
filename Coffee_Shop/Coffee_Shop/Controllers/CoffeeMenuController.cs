using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Shop.Controllers
{
    public class CoffeeMenuController : Controller
    {
        CoffeeMenuManager cm = new CoffeeMenuManager(new EfCoffeeMenuRepository());
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            Context c = new Context();
            var register = c.Registers.Where(x => x.UserMail == userMail).FirstOrDefault();
            var UserName = c.Registers.Where(x => x.UserMail == userMail).Select(x => x.UserName).FirstOrDefault();
            //ViewBag.UserName = UserName;
            TempData["UserName"] = UserName;
            var menu = cm.GetAllCoffeeMenu();
            if (register.RoleId == 1)
                return View("Index_Admin", menu);
            else
                return View(menu);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Add(CoffeeMenu coffeeMenu, IFormFile CoffeeMenuUrl)
        {
            CoffeeMenuValidator rv = new CoffeeMenuValidator();
            ValidationResult results = rv.Validate(coffeeMenu);



          
            var fileName = Path.GetFileName(CoffeeMenuUrl.FileName);

      
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

       
            using (var stream = new FileStream(path, FileMode.Create))
            {
                CoffeeMenuUrl.CopyTo(stream);
            }

        
            coffeeMenu.CoffeeMenuUrl = "/image/" + fileName;
            if (results.IsValid)
            {

                cm.AddCoffeeMenu(coffeeMenu);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }

        public IActionResult Delete(string Name)
        {
           var coffee= cm.GetAllCoffeeMenu().Where(x => x.CoffeeMenuName == Name).FirstOrDefault();
            cm.DeleteCoffeeMenu(coffee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string Name)
        {
           var coffee= cm.GetAllCoffeeMenu().Where(x=>x.CoffeeMenuName == Name).FirstOrDefault();

            return View(coffee);
        }


		[HttpPost]
		public IActionResult Update(CoffeeMenu coffeeMenu, IFormFile CoffeeMenuUrl)
		{
			CoffeeMenuValidator rv = new CoffeeMenuValidator();
			ValidationResult results = rv.Validate(coffeeMenu);

			var fileName = Path.GetFileName(CoffeeMenuUrl.FileName);
			
			var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

			using (var stream = new FileStream(path, FileMode.Create))
			{
				CoffeeMenuUrl.CopyTo(stream);
			}

			
			coffeeMenu.CoffeeMenuUrl = "/image/" + fileName;
			if (results.IsValid)
			{

				cm.UpdateCoffeeMenu(coffeeMenu);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			return RedirectToAction("Index");
		}

	}
}
