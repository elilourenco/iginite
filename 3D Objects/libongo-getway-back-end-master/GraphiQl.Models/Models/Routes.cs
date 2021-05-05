using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Routes
    {
        [Key]
        public string Id { get; set; }
        public string Name {get;set;} 
        public string ApiResourceId {get;set;} 
        [ForeignKey("ApiResourceId")]
        [InverseProperty("ApiResources")] 
        public virtual ApiResources ApiResources {get;set;} 
        public int HTTPSRedirectStatusCode {get;set;} 
        public bool RegexPriority {get;set;} 
        public string PathHandling {get;set;} 
        public bool StripPath {get;set;} 
        public bool PreserveHost {get;set;} 
        public virtual Paths Paths { get; set; }
        public virtual Methods Methods { get; set; }
        public string MicroServiceTypeId {get;set;} 
        [ForeignKey("MicroServiceTypeId")]
        [InverseProperty("MicroServiceType")] 
        public virtual MicroServiceType MicroServiceType {get;set;}
        public virtual Hosts Hosts { get; set; }
        public string SubCategoryRoutesId {get;set;} 
        [ForeignKey("SubCategoryRoutesId")]
        [InverseProperty("SubCategoryRoutes")] 
        public virtual CategoryRoutes SubCategoryRoutes {get;set;} 
         
        public virtual RoutesMethods RoutesMethods {get;set;} 

        public virtual Alerts Alerts {get;set;} 

        public virtual ICollection<SchemaRoute> SchemaRoute {get;set;} 
        public virtual ICollection<RoutesCanal> RoutesCanal {get;set;} 
        public virtual ICollection<TypeReturns> TypeReturns {get;set;} 

         
    } 
}
