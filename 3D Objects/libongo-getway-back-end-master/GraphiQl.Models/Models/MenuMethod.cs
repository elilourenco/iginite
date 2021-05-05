using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class MenuMethod
    {
        [Key]
        public string Id {get;set;} 
        
        public string MenuId {get;set;} 
        [ForeignKey("MenuId")]
        [InverseProperty("MenuMethod")] 
        public virtual Menu Menu {get;set;} 
        public string MethodId {get;set;} 
        [ForeignKey("MethodId")]
        [InverseProperty("MenuMethod")] 
        public virtual Methods Methods {get;set;} 
    }
    
}
