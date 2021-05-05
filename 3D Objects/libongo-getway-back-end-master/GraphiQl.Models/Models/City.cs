using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class City
    {
        [Key]
        public string Id {get;set;} 
        
        public string CityCod {get;set;} 
        public string Name {get;set;} 
        public string CountyId {get;set;} 
        [ForeignKey("CountyId")]
        [InverseProperty("City")] 
        public virtual Province Province {get;set;} 
        public string StatussId {get;set;} 
        [ForeignKey("StatussId")]
        [InverseProperty("City")] 
        public virtual Statuss Statuss {get;set;} 
    }
    
}
