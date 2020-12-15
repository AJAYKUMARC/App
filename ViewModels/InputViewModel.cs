using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class InputViewModel
    {
        public IList<SelectListItem> ProdutNumber { get; set; }
        public string ProductSelected { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionDate { get; set; }
    }
}
