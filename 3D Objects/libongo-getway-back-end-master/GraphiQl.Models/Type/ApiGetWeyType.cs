using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ApiGetWeyType : ObjectGraphType<ApiGetWey>
  {
    public ApiGetWeyType()
    {
      Name = "ApiGewey";
      Field(x => x.tipo, nullable: true);
      Field(x => x.url, nullable: true);
      Field(x => x.obj, nullable: true);
      Field(x => x.methodo, nullable: true);
      Field(x => x.mutation, nullable: true);
      Field(x => x.query, nullable: true);
      Field(x => x.RouteName, nullable: true);        
      Field(x => x.ServiceName, nullable: true);
      Field(x => x.ClientClientsId, nullable: true);
      Field(x => x.Routas, nullable: true);
      Field(x => x.Canal, nullable: true);
      //Field<ListGraphType<StringGraphType>>("objgraphql",resolve: context => ((ApiGetWey)context.Source).objgraphql.ToArray().ToString()); 
      Field<StringGraphType>("returnobj",resolve: context => ((ApiGetWey)context.Source).returnobj.ToString()); 
      FieldAsync<ListGraphType<ClientClientsType>> ("ClientClients", resolve : async c => c.Source.ClientClientsId==null?null: new manipulacao ().selectOne<ClientClients> (new ClientClients (), c.Source.ClientClientsId.ToString ()));
      Field(x => x.Localizacao, nullable: true,typeof(GeolocalizacaoType));
    }
  }
  public class ApiGetWeyInputType : InputObjectGraphType
  {
    public ApiGetWeyInputType()
    {
      Name = "ApiGeweytInput";
      Field<StringGraphType>("url"); 
      Field<StringGraphType>("tipo"); 
      Field<StringGraphType>("obj");
      Field<StringGraphType>("methodo");
      Field<StringGraphType>("ServiceName");     
      Field<StringGraphType>("RouteName"); 
      Field<StringGraphType>("Canal"); 
      Field<StringGraphType>("ClientClientsId"); 
      Field<StringGraphType>("mutation"); 
      Field<StringGraphType>("query"); 
    }
  }
}