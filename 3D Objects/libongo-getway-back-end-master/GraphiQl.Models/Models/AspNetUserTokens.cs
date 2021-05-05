using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class AspNetUserTokens
    {
        [Key]
        public string Id { get; set; }
        public string AspNetUsersId {get;set;} 
        [ForeignKey("AspNetUsersId")]
        [InverseProperty("AspNetUsers")] 
        public virtual AspNetUsers AspNetUsers {get;set;} 
        public string LoginProvider {get;set;} 
        public string Name {get;set;} 
        public string Value {get;set;} 
    }
    
}
