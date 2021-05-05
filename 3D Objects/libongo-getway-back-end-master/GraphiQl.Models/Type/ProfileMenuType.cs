using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ProfileMenuType : ObjectGraphType<ProfileMenu>
  {
    public ProfileMenuType()
    {
         Name = "ProfileMenu";
         Field(x => x.Id, nullable: true);
         FieldAsync<ListGraphType<PerfilMembersType>>("PerfilMembers", resolve : async c =>c.Source.PerfilMembersId == null?null :  new manipulacao().selectOne<PerfilMembers> (new PerfilMembers(),c.Source.PerfilMembersId.ToString()));
         FieldAsync<ListGraphType<MenuType>>("Menu", resolve : async c =>c.Source.MenuId == null?null :  new manipulacao().selectOne<Menu> (new Menu(),c.Source.MenuId.ToString()));
         FieldAsync<ListGraphType<ProfileMenuMethodsType>>("ProfileMenuMethods", resolve: async c => c.Source.Id == null ? null : new manipulacao().selectOne<ProfileMenuMethods>(new ProfileMenuMethods(), c.Source.Id.ToString()));
        }
  }
   public class ProfileMenuInputType: InputObjectGraphType
    {
        public ProfileMenuInputType()
        {
             Name = "ProfileMenuInput";
             Field<StringGraphType>("PerfilMembersId");
             Field<PerfilMembersInputType>("PerfilMembers");
             Field<StringGraphType>("MenuId");
             Field<MenuInputType>("Menu");
             Field<ListGraphType<ProfileMenuMethodsInputType>>("ProfileMenuMethods");
        }
    }

}
