using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Comments
{
    public class UpdateCommentRequestDto
    {
        public String Title { get; set; } = string.Empty;
        public String Content { get; set; } = string.Empty;
        
        
     
    }
}