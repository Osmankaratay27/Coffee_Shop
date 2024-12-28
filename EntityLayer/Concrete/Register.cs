using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Register
    {
        [Key]
        public int RegisterID { get; set; }
        public string? UserName { get; set; }
        public string? UserMail { get; set; }
        public string? UserPassword { get; set; }
        public bool? UserStatus { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Order> Orders { get; set; }
        public List<CreditCart> CreditCarts { get; set; }

    }
}
