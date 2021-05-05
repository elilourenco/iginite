using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class TypeAlert
    {
        [Key]
        public string Id {get;set;} 
        
        public string Type {get;set;} 
    }
    
}
