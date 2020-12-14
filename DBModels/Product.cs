using System;
using System.Collections.Generic;

#nullable disable

namespace App.DBModels
{
    public partial class Product
    {
        public Product()
        {
            Accounts = new HashSet<Account>();
        }

        public string ProdId { get; set; }
        public string ProdName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
