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
    public class CreditCartManager : ICreditCartService
    {
        ICreditCartDal iCreditCartDal;

        public CreditCartManager(ICreditCartDal iCreditCartDal)
        {
            this.iCreditCartDal = iCreditCartDal;
        }

        public void AddCreditCart(CreditCart creditCart)
        {
            iCreditCartDal.Add(creditCart);
        }

        public void DeleteCreditCart(CreditCart creditCart)
        {
            iCreditCartDal.Delete(creditCart);
        }

        public List<CreditCart> GetAllCreditCart()
        {
          return  iCreditCartDal.GetListAll();
        }

        public CreditCart GetCreditCartByID(int id)
        {
            return iCreditCartDal.GetByID(id);
        }

        public void UpdateCreditCart(CreditCart creditCart)
        {
            iCreditCartDal.Update(creditCart);
        }
    }
}
