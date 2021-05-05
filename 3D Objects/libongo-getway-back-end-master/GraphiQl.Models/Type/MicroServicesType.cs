using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class MicroServicesType : ObjectGraphType<MicroServices>
  {
    public MicroServicesType()
    {
      Name = "MicroServices";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
      FieldAsync<ListGraphType<MicroServiceTypeType>> ("MicroServiceType", resolve : async c => c.Source.Id==null?null:  new manipulacao ().selectOne<MicroServiceType> (new MicroServiceType (), c.Source.Id.ToString ()));
      
    }
  }
  public class MicroServicesInputType : InputObjectGraphType
  {
    public MicroServicesInputType()
    {
      Name = "MicroServicesInput";
      Field<StringGraphType>("Name"); 
    }
  }

}