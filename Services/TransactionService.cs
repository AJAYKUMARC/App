using App.DBModels;
using App.ViewModels;
using Microsoft.AspNetCore.Localization;
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
        private readonly db2AppContext db2AppContext;
        public TransactionService(dbAppContext context, db2AppContext db2AppContext)
        {
            this.context = context;
            this.db2AppContext = db2AppContext;
        }

        public List<JobsViewModel> GetJobsInfo()
        {
            var jobs = new List<JobsViewModel>();
            jobs.AddRange(context.TransactionLogs.Select(x => new JobsViewModel
            {
                JobId = x.JobId,
                RequestedBy = x.RequestedBy,
                RequestForm = x.FormName,
                StartAt = x.StartTime ?? DateTime.UtcNow,
                EndAt = x.EndTime ?? DateTime.UtcNow,
                Status = x.JobStatus
            }
            ).ToList());
            jobs.AddRange(db2AppContext.TransactionLogs.Select(x => new JobsViewModel
            {
                JobId = x.JobId,
                RequestedBy = x.RequestedBy,
                RequestForm = x.FormName,
                StartAt = x.StartTime ?? DateTime.UtcNow,
                EndAt = x.EndTime ?? DateTime.UtcNow,
                Status = x.JobStatus
            }
            ).ToList());
            return jobs;
        }

        public IList<SelectListItem> GetProduct()
        {
            return context.Products.Select(x => new SelectListItem { Text = x.ProdName, Value = x.ProdId }).ToList();
        }

        public IList<GridViewModel> GetTransactions(InputViewModel input)
        {

            TransactionLog transactionLog = new TransactionLog
            {
                FormName = "GetTransaction",
                JobStatus = "InProcess",
                RequestedBy = "User",
                StartTime = DateTime.UtcNow,
                CreatedBy = "User",
                UpdatedBy = "User",
                CreatedDatey = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };
            if (input.Environment == "Env-1")
            {
                context.TransactionLogs.Add(transactionLog);
                var saved = context.SaveChanges();

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
                    TransId = x.TransId,
                    AccountNumber = x.AccountId,
                    ProductNumber = x.ProdId,
                    TransactionAmount = x.TransAmt,
                    TransactionDescription = x.TransDesc,
                    TransactionDate = x.TransDte ?? DateTime.UtcNow
                }).ToList();

                var currentTransaction = context.TransactionLogs.FirstOrDefault(x => x.JobId == transactionLog.JobId);
                currentTransaction.EndTime = DateTime.UtcNow;
                currentTransaction.JobStatus = "Completed";
                context.SaveChanges();
                return result;
            }
            if (input.Environment == "Env-2")
            {
                db2AppContext.TransactionLogs.Add(transactionLog);
                var saved = db2AppContext.SaveChanges();
                var query = db2AppContext.Accounts.AsQueryable();

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
                    TransId = x.TransId,
                    AccountNumber = x.AccountId,
                    ProductNumber = x.ProdId,
                    TransactionAmount = x.TransAmt,
                    TransactionDescription = x.TransDesc,
                    TransactionDate = x.TransDte ?? DateTime.UtcNow
                }).ToList();

                var currentTransaction = db2AppContext.TransactionLogs.FirstOrDefault(x => x.JobId == transactionLog.JobId);
                currentTransaction.EndTime = DateTime.UtcNow;
                currentTransaction.JobStatus = "Completed";
                context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
