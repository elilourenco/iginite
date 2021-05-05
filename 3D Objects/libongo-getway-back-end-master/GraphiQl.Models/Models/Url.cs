using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Url
    {
        [Key]
        public string Id {get;set;} 
        
        public string Parameters {get;set;} public string IsObrigatory {get;set;} public string Type {get;set;} public string Description {get;set;} public string Example {get;set;} public DateTime CreationDate {get;set;} 
    }
    
}
