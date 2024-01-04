using Microsoft.EntityFrameworkCore.Internal;
using SalesWebMVC.Models;
using System;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        //criando um construtor 

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SaleRecord.Any())
            {
                return; //DB há been seeded
            }

            else
            {
                Department d1 = new Department(1, "Computers");
                Department d2 = new Department(2, "Eletronics");
                Department d3 = new Department(3, "Fashion");
                Department d4 = new Department(4, "Books");

                Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998,4,21), 1000.0, d1);
                Seller s2 = new Seller(2, "Vivi Kubo", "vivi@gmail.com", new DateTime(1985, 10, 22), 1200.0, d3);
                Seller s3 = new Seller(3, "Ted Bear", "ted@gmail.com", new DateTime(1995, 4, 18), 11000.0, d2);
                Seller s4 = new Seller(4, "Lucas Kubo", "bizungo@gmail.com", new DateTime(1998, 11, 10), 1000.0, d4);


                SalesRecord r1 = new SalesRecord(1, new DateTime(2018,09,25),11000.0, SaleStatus.Billed, s1);
                SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 10, 25), 1100.0, SaleStatus.Billed, s1);
                SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 06, 25), 112000.0, SaleStatus.Billed, s1);
                SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 07, 25), 1000.0, SaleStatus.Billed, s1);
                SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 02, 25), 2000.0, SaleStatus.Billed, s1);
                SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 01, 25), 45000.0, SaleStatus.Billed, s2);
                SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 03, 25), 121000.0, SaleStatus.Billed, s2);
                SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 04, 25), 101000.0, SaleStatus.Billed, s2);
                SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 11, 25), 9000.0, SaleStatus.Billed, s2);
                SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 12, 25), 141000.0, SaleStatus.Billed, s1);
                SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 01, 25), 800.0, SaleStatus.Billed, s3);
                SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 04, 25), 500.0, SaleStatus.Billed, s3);
                SalesRecord r13 = new SalesRecord(13, new DateTime(2018, 03, 25), 100.0, SaleStatus.Billed, s3);
                SalesRecord r14 = new SalesRecord(14, new DateTime(2018, 02, 25), 110000.0, SaleStatus.Billed, s4);
                SalesRecord r15 = new SalesRecord(15, new DateTime(2018, 05, 25), 141000.0, SaleStatus.Billed, s4);
                SalesRecord r16 = new SalesRecord(16, new DateTime(2018, 08, 25), 16000.0, SaleStatus.Billed, s4);


                _context.Department.AddRange(d1, d2, d3, d4);

                _context.Seller.AddRange(s1, s2, s3, s4);

                _context.SaleRecord.AddRange(r1,r2,r3,r4,r5,r6,r7,r8,r9,r10,r11,r12,r13,r14,r15,r16);

                _context.SaveChanges(); 


            }
            
        }
    }
}
