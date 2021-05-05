using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class MicroServiceTypeType : ObjectGraphType<MicroServiceType> {
    public MicroServiceTypeType () {
      Name = "MicroServiceType";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.MicroServiceId, nullable : true);
      FieldAsync<ListGraphType<MicroServicesType>> ("MicroService", resolve : async c => c.Source.MicroServiceId==null?null:  new manipulacao ().selectOne<MicroServices> (new MicroServices (), c.Source.MicroServiceId.ToString ()));
    }
  }
  public class MicroServiceTypeInputType : InputObjectGraphType {
    public MicroServiceTypeInputType () {
      Name = "MicroServiceTypeInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("MicroServiceId");
      Field<MicroServicesInputType> ("MicroServices");
    }
  }

}