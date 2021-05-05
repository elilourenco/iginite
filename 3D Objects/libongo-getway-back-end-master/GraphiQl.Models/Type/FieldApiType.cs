using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class FieldApiType : ObjectGraphType<FieldApi>
  {
    public FieldApiType()
    {
      Name = "FieldAp";
      Field(x => x.tipo, nullable: true);
      Field(x => x.url, nullable: true);
      Field(x => x.obj, nullable: true);
      Field(x => x.methodo, nullable: true);
      Field(x => x.RouteId , nullable: true);
      Field<StringGraphType>("returnobj",resolve: context => ((FieldApi)context.Source).returnobj.ToString()); 
    }
  }
  public class FieldApiTypeInputType : InputObjectGraphType
  {
    public FieldApiTypeInputType()
    {
      Name = "FieldApInput";
      Field<StringGraphType>("url"); 
      Field<StringGraphType>("tipo"); 
      Field<StringGraphType>("obj");
      Field<StringGraphType>("methodo");  
      Field<StringGraphType>("RouteId");
    }
  }
}