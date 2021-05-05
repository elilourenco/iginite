using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class NeighborhoodType : ObjectGraphType<Neighborhood> {
    public NeighborhoodType () {
      Name = "Neighborhood";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<DistrictType>> ("District", resolve : async c => c.Source.DistrictId == null?null : new manipulacao ().selectOne<District> (new District (), c.Source.DistrictId.ToString ()));
      Field (x => x.NeighborhoodCod, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.UpdateDate, nullable : true);
      FieldAsync<ListGraphType<StatussType>> ("Statuss", resolve : async c => c.Source.StatussId == null?null : new manipulacao ().selectOne<Statuss> (new Statuss (), c.Source.StatussId.ToString ()));
    }
  }
  public class NeighborhoodInputType : InputObjectGraphType {
    public NeighborhoodInputType () {
      Name = "NeighborhoodInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("DistrictId");
      Field<DistrictInputType> ("District");
      Field<StringGraphType> ("NeighborhoodCod");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
    }
  }

}