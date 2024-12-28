using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Shop.Controllers
{
    public class AdminController : Controller
    {
        OrderManager om = new OrderManager(new EfOrderRepository());
        CoffeeMenuManager cm = new CoffeeMenuManager(new EfCoffeeMenuRepository());
        RegisterManager rm = new RegisterManager(new EfRegisterRepository());
        Context c = new Context();
      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OrderIndex()
        { 
            var orders = om.GetOrderListWithRegister();
            return View(orders);
        }
     
        public IActionResult OrderStatus(string OrderName, string UserMail,int statusId)
        {

            var order = om.GetOrderListWithRegister().Where(x => x.Register.UserMail == UserMail && x.OrderName == OrderName).FirstOrDefault();
            order.OrderStatus = statusId;
            om.UpdateOrder(order);
            return RedirectToAction("OrderIndex");
        }
     

    }
}
