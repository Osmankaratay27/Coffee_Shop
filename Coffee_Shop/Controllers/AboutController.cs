using Microsoft.AspNetCore.Mvc;

namespace Coffee_Shop.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
