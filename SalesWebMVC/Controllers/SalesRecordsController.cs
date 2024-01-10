using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller

    {
        private readonly SalesRecordService _salesRecordService;


        //Construtor
        public SalesRecordsController(SalesRecordService salesRecordsService)
        {
            _salesRecordService = salesRecordsService;
        }



        public IActionResult Index()
        {
            return View();
        }



        
        // criando a busca simples

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }






        // criando a pesquisa de grupo

        public async Task<IActionResult>GroupSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateGroupAsync(minDate, maxDate);
            return View(result);

        }
    }
}
