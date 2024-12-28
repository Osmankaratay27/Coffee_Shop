using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-56OJ44O;database=Coffee_ShopDB; integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<CoffeeMenu> CoffeeMenus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<CreditCart> CreditCarts { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}
