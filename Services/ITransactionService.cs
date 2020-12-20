using App.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public interface ITransactionService
    {
        IList<SelectListItem> GetProduct();
        IList<GridViewModel> GetTransactions(InputViewModel input);
        List<JobsViewModel> GetJobsInfo();
    }
}
