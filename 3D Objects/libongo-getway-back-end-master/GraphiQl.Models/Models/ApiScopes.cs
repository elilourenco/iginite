using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ApiScopes
    {
        [Key]
        public string Id { get; set; }
        public bool Enabled {get;set;} 
        public string Name {get;set;} 
        public string DisplayName {get;set;} 
        public string Description {get;set;} 
        public bool Required {get;set;} 
        public bool Emphasize {get;set;} 
        public bool ShowInDiscoveryDocument {get;set;} 
    }
    
}
