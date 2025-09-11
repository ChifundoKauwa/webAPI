using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Stock
{
    public class UpdateStockRequestDto
    {  
          [Required]
        [MaxLength(10,ErrorMessage ="sysmbols must not exceed 10 characters")]
    
        public String Symbol { get; set; } = string.Empty;

          [Required]
        [MaxLength(40, ErrorMessage = "company name must not exceed 40 letters")]
        public String CompanyName { get; set; } = string.Empty;

        
         [Required]
        [Range(1,10000000000)]
    
        public decimal Purchase { get; set; }

         [Required]
        [Range(0.001,100)]
        public decimal LastDiv { get; set; }

              [Required]
        [MaxLength(40,ErrorMessage ="industry name cannot be over 40 letters")]
        public String Industry { get; set; } = string.Empty;

        [Required]
        [Range(0.00,10000000000000)]
        public long MarketCap { get; set; }
        
    
        
    }
}