using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models {
    public partial class IntervalUnits {

        [Key]
        public string Id { get; set; }
        public string Unit { get; set; }
        public string CodIntervalUnit { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime UpdateDate { get; set; }

    }

}