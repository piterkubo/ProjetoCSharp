// Importando o biblioteca SalesWebMVC Data
using SalesWebMVC.Data;

//importando a bilioteca model seller
using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Linq;

// importando a biblioteca para seguir com eager loading
using Microsoft.EntityFrameworkCore;
using System;

// importando a biblioteca notfound
using SalesWebMVC.Services.Exceptions;



// importando a biblioteca tasks
using System.Threading.Tasks;

// importando a biblioteca EntityFramework p / .Tolist ficar asincrona 
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }


        public async Task<List<Seller>> FindAll()
        {
            return await _context.Seller.ToListAsync();// async para asincrona deixar mais rapido
        }


        



        // metodo para inserir

        public async Task InsertAsync(Seller obj)
        {
            
            _context.Add(obj);
             await _context.SaveChangesAsync();

        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            // fazendo um join da tabela depto e vendedor com (Include)
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }


        //metodo para remover via logica

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }


        //metodo para editar via logica

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            
            if (!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }


            catch (DbUpdateConcurrencyException msg)
            {
                throw new DbConcurrencyException(msg.Message);
            }

            
        }
    }
}
