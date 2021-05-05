using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ApiScopesType : ObjectGraphType<ApiScopes> {
    public ApiScopesType () {
      Name = "ApiScopes";
      Field (x => x.Id, nullable : true);
      Field (x => x.Enabled, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.DisplayName, nullable : true);
      Field (x => x.Description, nullable : true);
      Field (x => x.Required, nullable : true);
      Field (x => x.Emphasize, nullable : true);
      Field (x => x.ShowInDiscoveryDocument, nullable : true);
    }
  }
  public class ApiScopesInputType : InputObjectGraphType {
    public ApiScopesInputType () {
      Name = "ApiScopesInput";
      Field<BooleanGraphType> ("Enabled");
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("DisplayName");
      Field<StringGraphType> ("Description");
      Field<BooleanGraphType> ("Required");
      Field<BooleanGraphType> ("Emphasize");
      Field<BooleanGraphType> ("ShowInDiscoveryDocument");
    }
  }

}