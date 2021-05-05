using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Headers
    {
        [Key]
        public string Id { get; set; }
        public string Header {get;set;} 
    }
    
}
