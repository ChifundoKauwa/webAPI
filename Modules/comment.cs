using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Modules
{
    public class Comment
    {
        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
        public int Id { get; set; }
        public String Title { get; set; } = string.Empty;
        public String Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;


    }
}