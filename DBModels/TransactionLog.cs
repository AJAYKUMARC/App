using System;
using System.Collections.Generic;

#nullable disable

namespace App.DBModels
{
    public partial class TransactionLog
    {
        public int JobId { get; set; }
        public string FormName { get; set; }
        public string RequestedBy { get; set; }
        public string JobStatus { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? CreatedDatey { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
