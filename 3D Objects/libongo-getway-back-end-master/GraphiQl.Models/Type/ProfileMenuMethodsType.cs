using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ProfileMenuMethodsType : ObjectGraphType<ProfileMenuMethods>
  {
    public ProfileMenuMethodsType()
    {
         Name = "ProfileMenuMethods";
         Field(x => x.Id, nullable: true);
         FieldAsync<ListGraphType<ProfileMenuType>>("ProfileMenu", resolve : async c =>c.Source.ProfileMenuId == null?null :  new manipulacao().selectOne<ProfileMenu> (new ProfileMenu(),c.Source.ProfileMenuId.ToString()));
         FieldAsync<ListGraphType<MethodsType>>("Methods", resolve : async c =>c.Source.MethodId == null?null :  new manipulacao().selectOne<Methods> (new Methods(),c.Source.MethodId.ToString()));
    }
  }
   public class ProfileMenuMethodsInputType: InputObjectGraphType
    {
        public ProfileMenuMethodsInputType()
        {
             Name = "ProfileMenuMethodsInput";
             Field<StringGraphType>("ProfileMenuId");
             Field<ProfileMenuInputType>("ProfileMenu");
             Field<StringGraphType>("MethodId");
             Field<MethodsInputType>("Methods");
        }
    }

}
