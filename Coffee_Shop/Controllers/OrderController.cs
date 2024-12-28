    using BusinessLayer.Concrete;
    using DataAccessLayer.Concrete;
    using DataAccessLayer.EntityFramework;
    using EntityLayer.Concrete;
    using Microsoft.AspNetCore.Mvc;

    namespace Coffee_Shop.Controllers
    {
        public class OrderController : Controller
        {
            OrderManager om = new OrderManager(new EfOrderRepository());
            CoffeeMenuManager cm = new CoffeeMenuManager(new EfCoffeeMenuRepository());
            RegisterManager rm= new RegisterManager(new EfRegisterRepository());
            Context c = new Context();
            public IActionResult Index()
            {
                var userMail = User.Identity.Name;
                var RegisterID = c.Registers.Where(x => x.UserMail == userMail).Select(x => x.RegisterID).FirstOrDefault();
                var orders = om.GetAllOrders().Where(x => x.RegisterID == RegisterID);
                return View(orders);
            }

            public IActionResult Delete(string name)
            {
                var userMail = User.Identity.Name;
                int RegisterID = c.Registers.Where(x => x.UserMail == userMail).Select(x => x.RegisterID).FirstOrDefault();
                var a = om.GetAllOrders().Where(o => o.OrderName == name && o.RegisterID == RegisterID).FirstOrDefault();
                var model2 = cm.GetAllCoffeeMenu().Where(o => o.CoffeeMenuName == name).FirstOrDefault();

                if (a != null)
                {
                    if (a.OrderCount == 1)
                    {
                        om.DeleteOrder(a);
                    }
                    else
                    {
                        a.OrderCount -= 1;
                        a.OrderPrice = model2.CoffeeMenuPrice * a.OrderCount;
                        om.UpdateOrder(a);

                    }

                }
                return RedirectToAction("Index");


            }

            public IActionResult Detail()
            {
                return View();

            }
            public IActionResult Add(string name)
            {
                var userMail = User.Identity.Name;
                int RegisterID = c.Registers.Where(x => x.UserMail == userMail).Select(x => x.RegisterID).FirstOrDefault();
                var a = om.GetAllOrders().Where(o => o.OrderName == name && o.RegisterID == RegisterID).FirstOrDefault();
                var model2 = cm.GetAllCoffeeMenu().Where(o => o.CoffeeMenuName == name).FirstOrDefault();

                if (a == null)
                {
                    var model = cm.GetAllCoffeeMenu().Where(o => o.CoffeeMenuName == name).FirstOrDefault();
                    Order ord = new Order();

                    ord.OrderUrl = model.CoffeeMenuUrl;
                    ord.OrderName = model.CoffeeMenuName;
                    ord.OrderPrice = model.CoffeeMenuPrice;
                    ord.OrderCount = 1;
                    ord.RegisterID = RegisterID;
                    ord.OrderStatus = 0;

                    om.AddOrder(ord);

                }
                else
                {
                    a.OrderCount += 1;
                    a.OrderPrice = model2.CoffeeMenuPrice * a.OrderCount;
                    om.UpdateOrder(a);

                }

                return RedirectToAction("Index");
            }

            public async Task<IActionResult> Add2(string name)
            {
                var userMail = User.Identity.Name;
                int RegisterID = c.Registers.Where(x => x.UserMail == userMail).Select(x => x.RegisterID).FirstOrDefault();
                var a = om.GetAllOrders().Where(o => o.OrderName == name && o.RegisterID == RegisterID).FirstOrDefault();
                var model2 = cm.GetAllCoffeeMenu().Where(o => o.CoffeeMenuName == name).FirstOrDefault();

                if (a == null)
                {
                    var model = cm.GetAllCoffeeMenu().Where(o => o.CoffeeMenuName == name).FirstOrDefault();
                    Order ord = new Order();
                    ord.OrderUrl = model.CoffeeMenuUrl;
                    ord.OrderName = model.CoffeeMenuName;
                    ord.OrderPrice = model.CoffeeMenuPrice;
                    ord.OrderCount = 1;
                    ord.RegisterID = RegisterID;
                    ord.OrderStatus = 0;
                    om.AddOrder(ord);

                }
                else
                {
                    a.OrderCount += 1;
                    a.OrderPrice = model2.CoffeeMenuPrice * a.OrderCount;
                    om.UpdateOrder(a);
                }
                return Redirect("~/CoffeeMenu/Index");
            }

        }
    }
