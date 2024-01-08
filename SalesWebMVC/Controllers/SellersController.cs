using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        //Declarando uma dependencia 

        private readonly SellerService _sellerService;

        private readonly DepartmentService _departmentService;


        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task <IActionResult> Index()
        {
            var list = await _sellerService.FindAll();
            return View(list);
        }

        // metodo create get para mostrar a view
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllasync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }


        // metodo create salvar banco via view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            //metodo para validar
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllasync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);

            }


            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }





        // Metodo via banco mostrar o que sera deletado

        public async Task <IActionResult> Delete(int? id)
        {
            
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }




        // metodo via post para deletar via view

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }



        // metodo via banco para mostrar (detalhes)

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }



        // metodo via edit

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            
            var obj = await _sellerService.FindByIdAsync(id.Value);

            
            if( obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }


            //carregar os depto para povoar a caixa de seleção
            List<Department> departments =  await _departmentService.FindAllasync();

            SellerFormViewModel viewModel = new SellerFormViewModel {Seller = obj, Departments = departments  };

            return View(viewModel);

                       

           
        }


        // metodo edit via post no banco

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {

            //metodo para validar
            if (!ModelState.IsValid)   
            {
                var departments = await _departmentService.FindAllasync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);

            }


            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id missmatch" });
            }

            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }

            catch (ApplicationException msg)
            {
                return RedirectToAction(nameof(Error), new { message = msg.Message });
            }

            
        }

        // metodo para uma ação do erro
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);

            
        }




    }
}
