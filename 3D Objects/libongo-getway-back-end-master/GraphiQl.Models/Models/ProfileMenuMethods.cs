using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ProfileMenuMethods
    {
        [Key]
        public string Id {get;set;} 
        
        public string ProfileMenuId {get;set;} [ForeignKey("ProfileMenuId")][InverseProperty("ProfileMenuMethods")] public virtual ProfileMenu ProfileMenu {get;set;} public string MethodId {get;set;} [ForeignKey("MethodId")][InverseProperty("ProfileMenuMethods")] public virtual Methods Methods {get;set;} 
    }
    
}
