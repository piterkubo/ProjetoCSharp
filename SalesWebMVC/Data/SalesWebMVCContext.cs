using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext (DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }

        //criando os dbset para enviar via banco

        public DbSet <Seller> Seller{ get; set; }

        public DbSet<SalesRecord> SaleRecord { get; set; }
    }
}
