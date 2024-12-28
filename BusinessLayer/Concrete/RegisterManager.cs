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
    public class RegisterManager : IRegisterService
    {
        IRegisterDal iRegisterDal;

        public RegisterManager(IRegisterDal iRegisterDal)
        {
            this.iRegisterDal = iRegisterDal;
        }

        public void AddUser(Register register)
        {
          iRegisterDal.Add(register);
        }

        public Register GetUser(int id)
        {
            return iRegisterDal.GetByID(id);
        }
    }
}
