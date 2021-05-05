using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class MenuPerfilType : ObjectGraphType<MenuPerfil> {
          public MenuPerfilType () {
               Name = "MenuPerfil";
               Field (x => x.Id, nullable : true);
               FieldAsync<ListGraphType<MenuType>> ("Menu", resolve : async c => c.Source.MenuId == null?null : new manipulacao ().selectOne<Menu> (new Menu (), c.Source.MenuId.ToString ()));
               FieldAsync<ListGraphType<PerfilMembersType>> ("PerfilMembers", resolve : async c => c.Source.PerfilMembersId == null?null : new manipulacao ().selectOne<PerfilMembers> (new PerfilMembers (), c.Source.PerfilMembersId.ToString ()));
          }
     }
     public class MenuPerfilInputType : InputObjectGraphType {
          public MenuPerfilInputType () {
               Name = "MenuPerfilInput";
               Field<StringGraphType> ("MenuId");
               Field<MenuInputType> ("Menu");
               Field<StringGraphType> ("PerfilMembersId");
               Field<PerfilMembersInputType> ("PerfilMembers");
          }
     }

}