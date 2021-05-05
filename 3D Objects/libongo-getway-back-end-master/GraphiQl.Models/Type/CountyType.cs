using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class CountyType : ObjectGraphType<County> {
    public CountyType () {
      Name = "County";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.ProvinceId, nullable : true);
      FieldAsync<ListGraphType<ProvinceType>> ("Province", resolve : async c => c.Source.ProvinceId == null?null : new manipulacao ().selectOne<Province> (new Province (), c.Source.ProvinceId.ToString ()));
      Field (x => x.ProvinceCod, nullable : true);
      Field (x => x.DataCriacao, nullable : true);
      Field (x => x.DataAtualizacao, nullable : true);
      FieldAsync<ListGraphType<StatussType>> ("Statuss", resolve : async c => c.Source.StatussId == null?null : new manipulacao ().selectOne<Statuss> (new Statuss (), c.Source.StatussId.ToString ()));
    }
  }
  public class CountyInputType : InputObjectGraphType {
    public CountyInputType () {
      Name = "CountyInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("ProvinceId");
      Field<ProvinceInputType> ("Province");
      Field<StringGraphType> ("ProvinceCod");
      Field<DateTimeGraphType> ("DataCriacao");
      Field<DateTimeGraphType> ("DataAtualizacao");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
    }
  }

}