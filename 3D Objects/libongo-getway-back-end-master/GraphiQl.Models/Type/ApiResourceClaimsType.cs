using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ApiResourceClaimsType : ObjectGraphType<ApiResourceClaims>
  {
    public ApiResourceClaimsType()
    {
            Name = "ApiResourceClaims";
            Field(x => x.Id, nullable: true);
            Field(x => x.Type, nullable: true);
            FieldAsync<ListGraphType<ApiResourcesType>>("ApiResources", resolve : async c => c.Source.ApiResourceId==null?null: new manipulacao().selectOne<ApiResources> (new ApiResources(),c.Source.ApiResourceId.ToString()));
    }
  }
   public class ApiResourceClaimsInputType: InputObjectGraphType
    {
        public ApiResourceClaimsInputType()
        {
             Name = "ApiResourceClaimsInput";
             Field<StringGraphType>("Type");Field<IntGraphType>("ApiResourceId");Field<ApiResourcesInputType>("ApiResources");
        }
    }

}
