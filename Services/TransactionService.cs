using App.DBModels;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace App.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly dbAppContext context;
        public TransactionService(dbAppContext context)
        {
            this.context = context;
        }
        public IList<SelectListItem> GetProduct()
        {
            return context.Products.Select(x => new SelectListItem { Text = x.ProdName, Value = x.ProdId }).ToList();
        }

        public IList<GridViewModel> GetTranscations(InputViewModel input)
        {
            var query = context.Accounts.AsQueryable();
            if (!string.IsNullOrEmpty(input.AccountNumber))
            {
                query = query.Where(x => x.AccountId == input.AccountNumber);
            }
            if (!string.IsNullOrEmpty(input.ProductSelected))
            {
                query = query.Where(x => x.ProdId == input.ProductSelected);
            }
            var result = query.Select(x => new GridViewModel
            {
                AccountNumber = x.AccountId,
                ProductNumber = x.ProdId,
                TransactionAmount = x.TransAmt,
                TransactionDescription = x.TransDesc,
                TransactionDate = x.TransDte ?? DateTime.UtcNow
            }).ToList();
            return result;
        }
    }
}
