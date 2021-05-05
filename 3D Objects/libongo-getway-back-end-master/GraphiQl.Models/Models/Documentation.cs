using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models {
    public partial class Documentation {

        
        [Key]
        public string Id { get; set; }
        
        
        public string RouteId { get; set; }

        [ForeignKey ("RouteId")]
        [InverseProperty ("Documentation")]
        public virtual Routes Routes { get; set; }
        public string MethodId { get; set; }
        [ForeignKey ("MethodId")]
        [InverseProperty ("Documentation")] 
        public virtual Methods Methods { get; set; } 

        public string PathsId { get; set; }
        [ForeignKey ("PathsId")]
        [InverseProperty ("Path")] 
        public virtual Paths Paths { get; set; } 

        public string BaseUrl { get; set; } 
        public string Obj { get; set; }
    }

}