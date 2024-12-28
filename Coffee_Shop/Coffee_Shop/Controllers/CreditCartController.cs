using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Coffee_Shop.Controllers
{
    public class CreditCartController : Controller
    {
        OrderManager om = new OrderManager(new EfOrderRepository());
        CreditCartManager ccm = new CreditCartManager(new EfCreditCartRepository());
        RegisterManager rm=new RegisterManager(new EfRegisterRepository());
        Context c = new Context();

        [HttpGet]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            var RegisterID = c.Registers.Where(x => x.UserMail == userMail).Select(x => x.RegisterID).FirstOrDefault();

            var carts = ccm.GetAllCreditCart().Where(x=>x.RegisterID==RegisterID);
            return View(carts);
        }
        [HttpGet]
        public IActionResult CreateCreditCart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCreditCart(CreditCart creditCart)
        {
            CreditCartValidator rv = new CreditCartValidator();
            ValidationResult results = rv.Validate(creditCart);
            var userMail = User.Identity.Name;
            var RegisterID = c.Registers.Where(x => x.UserMail == userMail).Select(x => x.RegisterID).FirstOrDefault();

            if (results.IsValid)
            {
                creditCart.RegisterID = RegisterID;
                ccm.AddCreditCart(creditCart);
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

      
        public IActionResult OrderPayment()
        {
            var userMail = User.Identity.Name;

            var orders = om.GetOrderListWithRegister().Where(x => x.Register.UserMail == userMail).ToList();

            foreach (var order in orders) 
            {
                order.OrderStatus = 1;
                om.UpdateOrder(order);
            }
            return RedirectToAction("Index","Order");
        }

        public IActionResult Delete(int CartId)
        {
            var userMail = User.Identity.Name;
            int RegisterID = c.Registers.Where(x => x.UserMail == userMail).Select(x => x.RegisterID).FirstOrDefault();
            
           var cart= ccm.GetAllCreditCart().Where(x => x.CartID == CartId).Where(x=>x.RegisterID==RegisterID).FirstOrDefault();


            ccm.DeleteCreditCart(cart);
               

           
            return RedirectToAction("Index");


        }

    }
}
