using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class MicroServiceType
    {
        [Key]
        public string Id { get; set; }
        public string Name {get;set;} 
        public string MicroServiceId {get;set;} 
        [ForeignKey("MicroServiceId")]
        [InverseProperty("MicroService")] 
        public virtual MicroServices MicroService {get;set;}  
    }
    
}
