using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Linq;

// importando a biblioteca tasks
using System.Threading.Tasks;

// importando a biblioteca EntityFramework p / .Tolist ficar asincrona 
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        // metodo para retornar todos os deptos

        public async Task<List<Department>> FindAllasync() // async para asincrona deixar mais rapido
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
