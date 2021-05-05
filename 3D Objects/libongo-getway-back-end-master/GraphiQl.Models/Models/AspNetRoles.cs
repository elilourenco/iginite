using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class AspNetRoles
    {
        [Key]
        public string Id { get; set; }
        public string Name {get;set;} 
        public string NormalizedName {get;set;} 
        public string ConcurrencyStamp {get;set;} 
    }
    
}
