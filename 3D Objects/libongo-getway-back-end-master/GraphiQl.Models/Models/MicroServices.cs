using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class MicroServices
    {
        [Key]
        public string Id {get;set;} 
        public string Name {get;set;} 

        public virtual MicroServiceType MicroServiceType {get;set;}
    }
}
