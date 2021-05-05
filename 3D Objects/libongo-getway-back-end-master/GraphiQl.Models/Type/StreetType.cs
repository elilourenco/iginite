using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class StreetType : ObjectGraphType<Street> {
    public StreetType () {
      Name = "Street";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.StreetCod, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.UpdateDate, nullable : true);
      FieldAsync<ListGraphType<StatussType>> ("Statuss", resolve : async c => c.Source.StatussId == null?null : new manipulacao ().selectOne<Statuss> (new Statuss (), c.Source.StatussId.ToString ()));
      FieldAsync<ListGraphType<NeighborhoodType>> ("Neighborhood", resolve : async c => c.Source.NeighborhoodId == null?null : new manipulacao ().selectOne<Neighborhood> (new Neighborhood (), c.Source.NeighborhoodId.ToString ()));
    }
  }
  public class StreetInputType : InputObjectGraphType {
    public StreetInputType () {
      Name = "StreetInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("StreetCod");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
      Field<StringGraphType> ("NeighborhoodId");
      Field<NeighborhoodInputType> ("Neighborhood");
    }
  }

}