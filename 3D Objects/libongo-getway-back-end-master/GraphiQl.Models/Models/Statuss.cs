using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Statuss
    {
        [Key]
        public string Id {get;set;} 
        
        public string Designation {get;set;} 
        public string StatusCode {get;set;} 
        public DateTime CreationDate {get;set;} 
        public DateTime UpdateDate {get;set;} 
        public string Obs {get;set;} 
    }
    
}
