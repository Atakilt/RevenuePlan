using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class RevenueViewModel
    {
        public decimal InBirr { get; set; }
        public List<RevenuType> RevenuTypesList { get; set; }
    }
}
