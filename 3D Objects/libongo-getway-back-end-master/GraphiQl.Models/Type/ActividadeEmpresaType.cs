using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ActivityCompanyType : ObjectGraphType<ActivityCompany>
  {
    public ActivityCompanyType()
    {
      Name = "ActivityCompany";
      Field(x => x.Id, nullable: true);
      Field(x => x.Description, nullable: true);
      Field(x => x.Designation, nullable: true);
    }
  }
  public class ActivityCompanyInputType : InputObjectGraphType
  {
    public ActivityCompanyInputType()
    {
      Name = "ActivityCompanyInput";
      Field<StringGraphType>("description");
      Field<StringGraphType>("designation");
    }
  }

}
