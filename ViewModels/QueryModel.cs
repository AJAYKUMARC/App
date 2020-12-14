using App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class QueryModel
    {
        public string Filed { get; set; }
        public ConditionTypes Condition { get; set; }
        public string Value { get; set; }
    }
}
