using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class IdentityResourcesType : ObjectGraphType<IdentityResources> {
    public IdentityResourcesType () {
      Name = "IdentityResources";
      Field (x => x.Id, nullable : true);
      Field (x => x.Enabled, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.DisplayName, nullable : true);
      Field (x => x.Description, nullable : true);
      Field (x => x.Required, nullable : true);
      Field (x => x.Emphasize, nullable : true);
      Field (x => x.ShowInDiscoveryDocument, nullable : true);
      Field (x => x.Created, nullable : true);
      Field (x => x.Updated, nullable : true);
      Field (x => x.NonEditable, nullable : true);
    }
  }
  public class IdentityResourcesInputType : InputObjectGraphType {
    public IdentityResourcesInputType () {
      Name = "IdentityResourcesInput";
      Field<BooleanGraphType> ("Enabled");
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("DisplayName");
      Field<StringGraphType> ("Description");
      Field<BooleanGraphType> ("Required");
      Field<BooleanGraphType> ("Emphasize");
      Field<BooleanGraphType> ("ShowInDiscoveryDocument");
      Field<DateTimeGraphType> ("Created");
      Field<DateTimeGraphType> ("Updated");
      Field<BooleanGraphType> ("NonEditable");
    }
  }
}