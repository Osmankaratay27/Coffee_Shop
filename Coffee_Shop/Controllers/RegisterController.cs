using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Coffee_Shop.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        RegisterManager rm= new RegisterManager(new EfRegisterRepository());

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(Register register)
        {
            RegisterValidator rv=new RegisterValidator();
            ValidationResult results=rv.Validate(register);


            if (results.IsValid)
            {
                register.UserStatus = true;
                register.RoleId = 2;
                
               
               rm.AddUser(register);
                return RedirectToAction("Index", "Home");
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
    }
}
