using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class MenuPerfil
    {
        [Key]
        public string Id {get;set;} 
        
        public string MenuId {get;set;} 
        [ForeignKey("MenuId")]
        [InverseProperty("MenuPerfil")] 
        public virtual Menu Menu {get;set;} 
        public string PerfilMembersId {get;set;} 
        [ForeignKey("PerfilMembersId")]
        [InverseProperty("MenuPerfil")] 
        public virtual PerfilMembers PerfilMembers {get;set;} 
    }
    
}
