using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class Persons
  {
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string NIF { get; set; }
    public int MembersNumber { get; set; }
    public string Sigla { get; set; }
    public string RegistryCompanyNumber { get; set; }
    public string PersonTypeId { get; set; }
    [ForeignKey("PersonTypeId")] 
    [InverseProperty("Persons")] 
    public virtual PersonType PersonType { get; set; }
    public string FilePath { get; set; }
    public string ActivityCompanyId { get; set; }
    [ForeignKey("ActivityCompanyId")] 
    [InverseProperty("Persons")] 
    public virtual ActivityCompany ActivityCompany { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public virtual AspNetUsers AspNetUsers { get; set; }
  }

}
