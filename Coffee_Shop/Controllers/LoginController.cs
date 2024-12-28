using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Coffee_Shop.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Register register)
        {
            Context c = new Context();
            var datavalue = c.Registers.FirstOrDefault(x=>x.UserMail==register.UserMail && x.UserPassword==register.UserPassword);
            if (datavalue!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,register.UserMail)
                };

                var useridentity = new ClaimsIdentity(claims , "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                if(datavalue.RoleId==1)
                return RedirectToAction("Index", "Admin");
                else
                return RedirectToAction("Index","CoffeeMenu");
            }
            else
            {
                return View();
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(); // Cookie'leri temizler ve oturumu sonlandırır
            return RedirectToAction("Index", "Login"); // Kullanıcıyı giriş sayfasına yönlendirir
        }
    }
}
