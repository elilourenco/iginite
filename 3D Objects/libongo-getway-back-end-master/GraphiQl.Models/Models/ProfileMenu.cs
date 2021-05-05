using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ProfileMenu
    {
        [Key]
        public string Id {get;set;} 
        
        public string PerfilMembersId { get;set;} 
        [ForeignKey("PerfilMembersId")]
        [InverseProperty("PerfilMembers")] 

        public virtual PerfilMembers PerfilMembers { get;set;} 

        public string MenuId {get;set;} 
        [ForeignKey("MenuId")]
        [InverseProperty("ProfileMenu")] 
        
        public virtual Menu Menu {get;set;}

        public virtual ICollection<ProfileMenuMethods> ProfileMenuMethods { get; set; }
    }
    
}
