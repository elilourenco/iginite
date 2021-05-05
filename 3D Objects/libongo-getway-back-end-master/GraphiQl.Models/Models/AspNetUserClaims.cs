using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class AspNetUserClaims
    {
        [Key]
        public string Id { get; set; }
        public string AspNetUsersId {get;set;} 
        [ForeignKey("AspNetUsersId")]
        [InverseProperty("AspNetUsers")] 
        public virtual AspNetUsers AspNetUsers {get;set;} 
        public string ClaimType {get;set;} 
        public string ClaimValue {get;set;} 
    }
    
}
