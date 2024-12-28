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
    public class OrderManager : IOrderService
    {
        IOrderDal iOrderDal;

        public OrderManager(IOrderDal iOrderDal)
        {
            this.iOrderDal = iOrderDal;
        }

        public void AddOrder(Order order)
        {
          iOrderDal.Add(order);
        }

        public void DeleteOrder(Order order)
        {
           iOrderDal.Delete(order);
        }

        public List<Order> GetAllOrders()
        {
            return iOrderDal.GetListAll();
        }

        public List<Order> GetOrderListWithRegister()
        {
            return iOrderDal.GetOrderListWithRegister();
        }

        public Order GetOrderByID(int id)
        {
           return iOrderDal.GetByID(id);
        }

        public void UpdateOrder(Order order)
        {
            iOrderDal.Update(order);
        }
    }
}
