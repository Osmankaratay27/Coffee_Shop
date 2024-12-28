using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CreditCart
    {
        [Key]
        public int CartID { get; set; }
        public string CartName { get; set; }
        public string CartNumber { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }

        public int CVV { get; set;}
        public int RegisterID { get; set;}
        public Register Register { get; set; }

    }
}
