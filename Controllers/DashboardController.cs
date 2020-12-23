using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using App.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Controllers
{
    public class DashboardController : Controller
    {
        public readonly ITransactionService transactionService;
        public DashboardController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TransactionView()
        {
            IList<SelectListItem> productList = transactionService.GetProduct();
            return View(new TransactionViewModel { Input = new InputViewModel { ProdutNumber = productList } });
        }

        public IActionResult GetTansactions(InputViewModel input)
        {
            IList<SelectListItem> productList = transactionService.GetProduct();
            IList<GridViewModel> transactions = transactionService.GetTransactions(input);
            return View("TransactionView", new TransactionViewModel
            {
                Input = new InputViewModel { ProdutNumber = productList },
                GridView = transactions
            });
        }

        public IActionResult ViewJobs()
        {
            List<JobsViewModel> jobs = transactionService.GetJobsInfo();
            return View(jobs);
        }

        public IActionResult TestJQuery()
        {
            return View("Index1");
        }
    }
}
