using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class DatasheetType : ObjectGraphType<Datasheet> {
    public DatasheetType () {
      Name = "Datasheet";
      Field (x => x.Id, nullable : true);
      Field (x => x.Title, nullable : true);
      Field (x => x.Version, nullable : true);
      Field (x => x.Status, nullable : true);
      Field (x => x.Classification, nullable : true);
      Field (x => x.TypeDocument, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.ApiResourceId, nullable : true);
      FieldAsync<ListGraphType<ApiResourcesType>>("ApiResources", resolve: async c =>c.Source.ApiResourceId == null?null : new manipulacao().selectOne<ApiResources>(new ApiResources(), c.Source.ApiResourceId.ToString()));
    }
  }
  public class DatasheetInputType : InputObjectGraphType {
    public DatasheetInputType () {
      Name = "DatasheetInput";
      Field<StringGraphType> ("ApiResourceId");
      Field<StringGraphType> ("Title");
      Field<StringGraphType> ("Version");
      Field<StringGraphType> ("Status");
      Field<StringGraphType> ("Classification");
      Field<StringGraphType> ("TypeDocument");
      Field<DateTimeGraphType> ("CreationDate");
    }
  }

}