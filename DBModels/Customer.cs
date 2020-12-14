using System;
using System.Collections.Generic;

#nullable disable

namespace App.DBModels
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
        }

        public string CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public string ProdId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string Ssn { get; set; }
        public DateTime? Dob { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
