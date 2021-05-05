using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class AspNetUserRoles
    {
        public string AspNetUserId {get;set;} 
        [ForeignKey("AspNetUserId")]
        [InverseProperty("AspNetUser")] 
        public virtual AspNetUsers AspNetUsers {get;set;} 
        public string AspNetRoleId {get;set;} 
        [ForeignKey("AspNetRole")]
        [InverseProperty("AspNetRole")] 
        public virtual AspNetRoles AspNetRoles {get;set;} 
    }
    
}
