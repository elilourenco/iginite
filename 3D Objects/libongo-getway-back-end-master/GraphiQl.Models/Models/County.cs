using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class County
    {
        [Key]
        public string Id {get;set;} 
        public string Name {get;set;} 
        public string ProvinceId {get;set;} 
        [ForeignKey("ProvinceId")]
        [InverseProperty("County")] 
        public virtual Province Province {get;set;}  
        public string ProvinceCod {get;set;} 
        public DateTime DataCriacao {get;set;} 
        public DateTime DataAtualizacao {get;set;} 
        public string StatussId {get;set;} 
        [ForeignKey("StatussId")]
        [InverseProperty("County")] 
        public virtual Statuss Statuss {get;set;} 

    }
    
}
