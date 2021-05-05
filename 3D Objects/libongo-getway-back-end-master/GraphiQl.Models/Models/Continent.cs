using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Continent
    {
        [Key]
        public string Id {get;set;} 
        
        public string Name {get;set;} 
        public string CodContinent {get;set;} 
        public DateTime CreationDate {get;set;} 
        public DateTime UpdateDate {get;set;} 
        public string StatussId {get;set;} 
        [ForeignKey("StatussId")]
        [InverseProperty("Continent")] 
        public virtual Statuss Statuss {get;set;} 
    }
    
}
