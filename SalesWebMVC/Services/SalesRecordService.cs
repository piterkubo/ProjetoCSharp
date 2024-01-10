using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Linq;




namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        // declarar uma dependencia do entityFramework
        private readonly SalesWebMVCContext _context;

        public SalesRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }


        //criando um metodo para pesquisa simples
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SaleRecord select obj;
            
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }


            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }



        // criando um metodo para pesquisa em grupo

        public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SaleRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }


            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }

    }

}

