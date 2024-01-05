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

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }


        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }


        // metodo para inserir

        public void Insert(Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();

        }

        public Seller FindById(int id)
        {
            // fazendo um join da tabela depto e vendedor com (Include)
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }


        //metodo para remover via logica

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }


        //metodo para editar via logica

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not Found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }


            catch (DbUpdateConcurrencyException msg)
            {
                throw new DbConcurrencyException(msg.Message);
            }

            
        }
    }
}
