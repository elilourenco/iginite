using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Tags
    {
        [Key]
        public string Id { get; set;}
        public string Tag {get;set;} 
    }
    
}
