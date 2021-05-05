using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ClientsType : ObjectGraphType<Clients>
  {
    public ClientsType()
    {
      Name = "Clients";
      Field(x => x.Id, nullable: true);
      Field(x => x.Enabled, nullable: true); 
      Field(x => x.ProtocolType, nullable: true); 
      Field(x => x.RequireClientSecret, nullable: true); 
      Field(x => x.PersonsId, nullable: true); 
      Field(x => x.Description, nullable: true); 
      Field(x => x.ClientUri, nullable: true); 
      Field(x => x.LogoUri, nullable: true); 
      Field(x => x.RequireConsent, nullable: true); 
      Field(x => x.AllowRememberConsent, nullable: true); 
      Field(x => x.RequirePkce, nullable: true); 
      Field(x => x.AllowPlainTextPkce, nullable: true); 
      Field(x => x.RequireRequestObject, nullable: true); 
      Field(x => x.AllowAccessTokensViaBrowser, nullable: true); 
      Field(x => x.FrontChannelLogoutUri, nullable: true); 
      Field(x => x.FrontChannelLogoutSessionRequired, nullable: true); 
      Field(x => x.BackChannelLogoutUri, nullable: true); 
      Field(x => x.BackChannelLogoutSessionRequired, nullable: true); 
      Field(x => x.AllowOfflineAccess, nullable: true); 
      Field(x => x.AccessTokenLifetime, nullable: true); 
      Field(x => x.AuthorizationCodeLifetime, nullable: true); 
      Field(x => x.ConsentLifetime, nullable: true); 
      Field(x => x.AbsoluteRefreshTokenLifetime, nullable: true); 
      Field(x => x.SlidingRefreshTokenLifetime, nullable: true); 
      Field(x => x.RefreshTokenUsage, nullable: true); 
      Field(x => x.UpdateAccessTokenClaimsOnRefresh, nullable: true); 
      Field(x => x.RefreshTokenExpiration, nullable: true); 
      Field(x => x.AccessTokenType, nullable: true); 
      Field(x => x.EnableLocalLogin, nullable: true); 
      Field(x => x.AlwaysSendClientClaims, nullable: true); 
      Field(x => x.ClientClaimsPrefix, nullable: true); 
      Field(x => x.PairWiseSubjectSalt, nullable: true); 
      Field(x => x.Created, nullable: true); 
      Field(x => x.Updated, nullable: true); 
      Field(x => x.LastAccessed, nullable: true); 
      Field(x => x.UserSsoLifetime, nullable: true); 
      Field(x => x.UserCodeType, nullable: true); 
      Field(x => x.DeviceCodeLifetime, nullable: true); 
      Field(x => x.NonEditable, nullable: true);
      FieldAsync<ListGraphType<ApiResourcesType>>("ApiResources", resolve: async c =>c.Source.Id == null?null : new manipulacao().selectOne<ApiResources>(new ApiResources(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<ClientClientsType>>("ClientClients", resolve: async c =>c.Source.Id == null?null : new manipulacao().selectOne<ClientClients>(new ClientClients(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<PersonsType>>("Persons", resolve: async c =>c.Source.PersonsId == null?null : new manipulacao().selectOne<Persons>(new Persons(), c.Source.PersonsId.ToString()));
      
    }
  }
   public class ClientsInputType: InputObjectGraphType
    {
        public ClientsInputType()
        {
            Name = "ClientsInput";
            Field<BooleanGraphType>("Enabled");
            Field<StringGraphType>("ProtocolType");
            Field<BooleanGraphType>("RequireClientSecret");
            Field<StringGraphType>("PersonsId");
            Field<StringGraphType>("Description");
            Field<StringGraphType>("ClientUri");
            Field<StringGraphType>("LogoUri");
            Field<BooleanGraphType>("RequireConsent");
            Field<BooleanGraphType>("AllowRememberConsent");
            Field<BooleanGraphType>("RequirePkce");
            Field<BooleanGraphType>("AllowPlainTextPkce");
            Field<BooleanGraphType>("RequireRequestObject");
            Field<BooleanGraphType>("AllowAccessTokensViaBrowser");
            Field<StringGraphType>("FrontChannelLogoutUri");
            Field<BooleanGraphType>("FrontChannelLogoutSessionRequired");
            Field<StringGraphType>("BackChannelLogoutUri");
            Field<BooleanGraphType>("BackChannelLogoutSessionRequired");
            Field<BooleanGraphType>("AllowOfflineAccess");
            Field<IntGraphType>("AccessTokenLifetime");
            Field<IntGraphType>("AuthorizationCodeLifetime");
            Field<IntGraphType>("ConsentLifetime");
            Field<IntGraphType>("AbsoluteRefreshTokenLifetime");
            Field<IntGraphType>("SlidingRefreshTokenLifetime");
            Field<IntGraphType>("RefreshTokenUsage");
            Field<BooleanGraphType>("UpdateAccessTokenClaimsOnRefresh");
            Field<IntGraphType>("RefreshTokenExpiration");
            Field<IntGraphType>("AccessTokenType");
            Field<BooleanGraphType>("EnableLocalLogin");
            Field<BooleanGraphType>("AlwaysSendClientClaims");
            Field<StringGraphType>("ClientClaimsPrefix");
            Field<StringGraphType>("PairWiseSubjectSalt");
            Field<DateTimeGraphType>("Created");
            Field<DateTimeGraphType>("Updated");
            Field<DateTimeGraphType>("LastAccessed");
            Field<IntGraphType>("UserSsoLifetime");
            Field<StringGraphType>("UserCodeType");
            Field<IntGraphType>("DeviceCodeLifetime");
            Field<BooleanGraphType>("NonEditable");
            //Field<PersonsInputType>("persons");
        }
    }

}
