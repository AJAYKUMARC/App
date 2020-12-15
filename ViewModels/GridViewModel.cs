using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class GridViewModel
    {
        public string AccountNumber { get; set; }
        public string ProductNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
