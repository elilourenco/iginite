using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ActivityCompany
    {
        [Key]
        public string Id {get;set;} 
        public string Designation {get;set;} 
        public string Description {get;set;}  
    }
}