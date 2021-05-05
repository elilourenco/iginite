using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ApiResourcePropertiesType : ObjectGraphType<ApiResourceProperties> {
    public ApiResourcePropertiesType () 
    {
      Name = "ApiResourceProperties";

      Field (x => x.Id, nullable : true);
      Field (x => x.Keys, nullable : true);
      Field (x => x.Value, nullable : true);
      FieldAsync<ListGraphType<ApiResourcesType>> ("ApiResources", resolve : async c => c.Source.ApiResourceId == null?null : new manipulacao ().selectOne<ApiResources> (new ApiResources (), c.Source.ApiResourceId.ToString ()));

    }
  }
  public class ApiResourcePropertiesInputType : InputObjectGraphType {
    public ApiResourcePropertiesInputType () {

      Name = "ApiResourcePropertiesInput";
      Field<StringGraphType> ("Key");
      Field<StringGraphType> ("Value");
      Field<IntGraphType> ("ApiResourceId");
      Field<ApiResourcesInputType> ("ApiResources");

    }
  }

}