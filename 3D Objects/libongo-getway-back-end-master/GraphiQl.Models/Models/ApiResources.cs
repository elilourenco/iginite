using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ApiResources
    {
        [Key]
        public string Id { get; set; }
        public bool Enabled {get;set;} 
        public string Name {get;set;} 
        public string DisplayName {get;set;} 
        public string Description {get;set;} 
        public string AllowedAccessTokenSigningAlgorithms {get;set;} 
        public bool ShowInDiscoveryDocument {get;set;} 
        public DateTime Created {get;set;} 
        public DateTime Updated {get;set;} 
        public DateTime LastAccessed {get;set;} 
        public bool NonEditable {get;set;} 
        public string host {get;set;} 
        public string path {get;set;}
        public int port {get;set;} 
        public int retries {get;set;} 
        public int connectTimeout {get;set;} 
        public int writeTimeout {get;set;} 
        public int readTimeout {get;set;} 
        public string clientCertificate {get;set;} 
        public string Protocol {get;set;} 
        public string ClientId { get; set; }
        [ForeignKey("ClientId")]
        [InverseProperty("Clients")]
        public virtual Clients Clients { get; set; }
        public string TypeId { get; set; }
        [ForeignKey("TypeId")]
        [InverseProperty("Types")]
        public virtual Types Types { get; set; }
        public virtual Routes Routes { get; set; }
        public virtual ICollection<MicroServiceConfig> MicroServiceConfig { get; set; }
    }
    
}
