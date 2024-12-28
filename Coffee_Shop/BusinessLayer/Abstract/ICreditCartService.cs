using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICreditCartService
    {
        void AddCreditCart(CreditCart creditCart);
        void DeleteCreditCart(CreditCart creditCart);
        void UpdateCreditCart(CreditCart creditCart);
        List<CreditCart> GetAllCreditCart();
        CreditCart GetCreditCartByID(int id);
    }
}
