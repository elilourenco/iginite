using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class StatusCode
  {
    [Key]
    public string Id { get; set; }

    public string Code { get; set; }
    public string CodStatusCode { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
  }

}
