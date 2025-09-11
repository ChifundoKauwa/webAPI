using api.Modules; using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Modules
{
    public class Stock
    {
        public int Id { get; set; }
        public String Symbol { get; set; } = string.Empty;
        public String CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public String Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<Comment> comments { get; set; } = new List<Comment>();
    }
    
}