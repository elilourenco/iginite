using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Item
    {
        [Key]
        public string Id {get;set;} 
        
        public string ItemName {get;set;} public string Description {get;set;} public DateTime CreationDate {get;set;} 
    }
    
}
