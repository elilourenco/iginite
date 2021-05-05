using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ApiDocumentationType : ObjectGraphType<ApiDocumentation>
  {
    public ApiDocumentationType()
    {
      Name = "ApiGet";
      Field(x => x.tipo, nullable: true);
      Field(x => x.url, nullable: true);
      Field(x => x.obj, nullable: true);
      Field(x => x.methodo, nullable: true);
      Field(x => x.mutation, nullable: true);
      Field(x => x.query, nullable: true);
      Field(x => x.RouteId, nullable: true);       
      Field(x => x.MethodsId, nullable: true); 
      Field(x => x.AspNetUsersId, nullable: true);
      Field(x => x.EnsureSuccessStatusCode, nullable: true);   
      Field<StringGraphType>("data",resolve: context => ((ApiDocumentation)context.Source).data.ToString()); 
      Field(x => x.Documentationheader, nullable: true,typeof(DocumentationheaderType)); 
      FieldAsync<ListGraphType<RoutesMethodsType>> ("Getmethod", resolve : async c => c.Source.RouteId==null?null: new manipulacao ().selectOne<RoutesMethods> (new RoutesMethods (), c.Source.RouteId.ToString ()));
      
    }
  }
  public class ApiDocumentationInputType : InputObjectGraphType
  {
    public ApiDocumentationInputType()
    {
      Name = "ApiGetInput";
      Field<StringGraphType>("url"); 
      Field<StringGraphType>("tipo"); 
      Field<StringGraphType>("obj");
      Field<StringGraphType>("RouteId");
      Field<StringGraphType>("AspNetUsersId");
      Field<StringGraphType>("MethodsId");
      Field<StringGraphType>("methodo");
    }
  }


  public class DocumentationheaderType : ObjectGraphType<Documentationheader>
  {
    public DocumentationheaderType()
    {
      Name = "header";
      Field(x => x.description, nullable: true);
      Field(x => x.version, nullable: true);
      Field(x => x.termsOfService, nullable: true); 
      Field(x => x.title, nullable: true); 
      Field(x => x.contacts, nullable: true,typeof(contactType));        
    }
  }

  public class contactType : ObjectGraphType<contacts>
  {
    public contactType()
    {
      Name = "contacts";
      Field(x => x.email, nullable: true);
      Field(x => x.contact, nullable: true);      
    }
  }

}