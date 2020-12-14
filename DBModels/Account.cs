using System;
using System.Collections.Generic;

#nullable disable

namespace App.DBModels
{
    public partial class Account
    {
        public string AccountId { get; set; }
        public string CustomerId { get; set; }
        public string ProdId { get; set; }
        public string TransDesc { get; set; }
        public decimal TransAmt { get; set; }
        public DateTime? TransDte { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Prod { get; set; }
    }
}
