using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class PerfilMembersType : ObjectGraphType<PerfilMembers> {
    public PerfilMembersType () {
      Name = "PerfilMembers";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<ProfileMenuType>>("ProfileMenu", resolve: async c => c.Source.Id == null ? null : new manipulacao().selectOne<ProfileMenu>(new ProfileMenu(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<PerfilClientType>>("PerfilClient", resolve: async c => c.Source.Id == null ? null : new manipulacao().selectOne<PerfilClient>(new PerfilClient(), c.Source.Id.ToString()));
    }
  }
  public class PerfilMembersInputType : InputObjectGraphType {
    public PerfilMembersInputType () {
      Name = "PerfilMembersInput";
      Field<StringGraphType> ("Name");
      Field<ListGraphType<ProfileMenuInputType>>("ProfileMenu");
      Field<PerfilClientInputType>("PerfilClient");
    }
  }
}