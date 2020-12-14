using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TransactionView()
        {
            return View(new TransactionViewModel());
        }
    }
}
