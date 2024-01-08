using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        // criando a busca simples

        public IActionResult SimpleSearch()
        {
            return View();
        }


        // criando a pesquisa de grupo

        public IActionResult GroupSearch()
        {
            return View();
        }
    }
}
