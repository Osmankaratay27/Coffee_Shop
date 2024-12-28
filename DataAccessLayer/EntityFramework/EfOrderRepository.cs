using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfOrderRepository:GenericRepository<Order>,IOrderDal
	{
        public List<Order> GetOrderListWithRegister()
        {
            using (var c = new Context())
            {
                return c.Orders.Include(x => x.Register).ToList();
            }
        }
    }
}
