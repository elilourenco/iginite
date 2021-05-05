using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class SmsError
    {
      public string SqlError_1 { get; set; }
      public string SqlError_2 {get;set;}

      public string recomendation {get;set;}
    }
    
}
