using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ApiResourceSecretsType : ObjectGraphType<ApiResourceSecrets> {
    public ApiResourceSecretsType () {
      Name = "ApiResourceSecrets";
      Field (x => x.Id, nullable : true);
      Field (x => x.Description, nullable : true);
      Field (x => x.Value, nullable : true);
      Field (x => x.Expiration, nullable : true);
      Field (x => x.Type, nullable : true);
      Field (x => x.Created, nullable : true);
      FieldAsync<ListGraphType<ApiResourcesType>> ("ApiResources", resolve : async c => c.Source.ApiResourceId==null?null: new manipulacao ().selectOne<ApiResources> (new ApiResources (), c.Source.ApiResourceId.ToString ()));
    }
  }
  public class ApiResourceSecretsInputType : InputObjectGraphType {
    public ApiResourceSecretsInputType () {
      Name = "ApiResourceSecretsInput";
      Field<StringGraphType> ("Description");
      Field<StringGraphType> ("Value");
      Field<DateTimeGraphType> ("Expiration");
      Field<StringGraphType> ("Type");
      Field<DateTimeGraphType> ("Created");
      Field<IntGraphType> ("ApiResourceId");
      Field<ApiResourcesInputType> ("ApiResources");
    }
  }

}