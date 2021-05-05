using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class SpecialRoutes
    {
        [Key]
        public string Id {get;set;} 
        
        public string Name {get;set;} 
        public string AspnetusersId {get;set;} 
        [ForeignKey("AspnetusersId")]
        [InverseProperty("SpecialRoutes")] 
        public virtual AspNetUsers AspNetUsers {get;set;} 
    }
    
}
