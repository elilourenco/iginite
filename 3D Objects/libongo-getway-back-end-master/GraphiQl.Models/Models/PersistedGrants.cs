using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class PersistedGrants
    {
        [Key]
        public string Id { get; set; }
        public string Key {get;set;} 
        public string Type {get;set;}
        public string Description {get;set;} 
        public DateTime CreationTime {get;set;} 
        public DateTime Expiration {get;set;} 
        public DateTime ConsumedTime {get;set;} 
        public string Data {get;set;} 
    }
    
}
