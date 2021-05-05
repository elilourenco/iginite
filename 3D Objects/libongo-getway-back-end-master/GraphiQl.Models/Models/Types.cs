using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Types
    {
        [Key]
        public string Id { get; set; }
        public string Name {get;set;} 
    }
    
}
