using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class JobsViewModel
    {
        public int JobId { get; set; }
        public string RequestedBy { get; set; }
        public string RequestForm { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Status { get; set; }
    }
}
