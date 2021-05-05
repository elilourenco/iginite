using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class IdentityResourcePropertiesType : ObjectGraphType<IdentityResourceProperties> {
    public IdentityResourcePropertiesType () {
      Name = "IdentityResourceProperties";
      Field (x => x.Id, nullable : true);
      Field (x => x.Key, nullable : true);
      Field (x => x.Value, nullable : true);
      FieldAsync<ListGraphType<IdentityResourcesType>> ("IdentityResources", resolve : async c => c.Source.IdentityResourceId == null?null : new manipulacao ().selectOne<IdentityResources> (new IdentityResources (), c.Source.IdentityResourceId.ToString ()));
    }
  }
  public class IdentityResourcePropertiesInputType : InputObjectGraphType {
    public IdentityResourcePropertiesInputType () {
      Name = "IdentityResourcePropertiesInput";
      Field<StringGraphType> ("Key");
      Field<StringGraphType> ("Value");
      Field<IntGraphType> ("IdentityResourceId");
      Field<IdentityResourcesInputType> ("IdentityResources");
    }
  }

}