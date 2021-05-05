using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class PerfilMembers
    {
        [Key]
        public string Id {get;set;} 
        public string Name {get;set;}
        public virtual ICollection<ProfileMenu> ProfileMenu { get; set; }
        public virtual PerfilClient PerfilClient { get; set; }
    }
}
