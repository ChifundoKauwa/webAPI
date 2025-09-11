using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Comments
{
    public class CommentDto
    {
       
    
        public int? StockId { get; set; }
       
        public int Id { get; set; }
        public String Title { get; set; } = string.Empty;
        public String Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
     
    }
}