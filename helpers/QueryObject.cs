using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.helpers
{
    public class QueryObject
    {
        public String? Symbol { get; set; } = null;
        public String? CompanyName { get; set; } = null;
        public String? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}