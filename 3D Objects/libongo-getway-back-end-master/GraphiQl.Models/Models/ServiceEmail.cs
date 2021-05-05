using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ServiceEmail
    {
        [Key]
        public string Id {get;set;} 
        
        public int Port {get;set;} public string Host {get;set;} public string Email {get;set;} public string Password {get;set;} 
    }
    
}
