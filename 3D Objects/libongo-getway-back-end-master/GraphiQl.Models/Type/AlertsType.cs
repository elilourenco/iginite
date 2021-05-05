using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class AlertsType : ObjectGraphType<Alerts> {
    public AlertsType () {
      Name = "Alerts";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.Description, nullable : true);
      Field (x => x.MetricThreshold, nullable : true);
      Field (x => x.MeasurementIntervalValue, nullable : true);
      FieldAsync<ListGraphType<IntervalUnitsType>> ("IntervalUnits", resolve : async c => c.Source.MeasurementIntervaUnitId == null ? null : new manipulacao ().selectOne<IntervalUnits> (new IntervalUnits (), c.Source.MeasurementIntervaUnitId.ToString ()));
      Field (x => x.CodAlert, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.UpdateDate, nullable : true);
      Field (x => x.State, nullable : true); 
      Field (x => x.MetricTypeId, nullable : true);
      Field (x => x.MetricConditionId, nullable : true);
      Field (x => x.RouteId,nullable : true);
      FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c => c.Source.RouteId == null ? null : new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
      FieldAsync<ListGraphType<MetricTypesType>> ("MetricTypes", resolve : async c => c.Source.MetricTypeId == null ? null : new manipulacao ().selectOne<MetricTypes> (new MetricTypes (), c.Source.MetricTypeId.ToString ()));
      FieldAsync<ListGraphType<MetricConditionsType>> ("MetricConditions", resolve : async c => c.Source.MetricConditionId == null ? null : new manipulacao ().selectOne<MetricConditions> (new MetricConditions (), c.Source.MetricConditionId.ToString ()));


    }
  }
  public class AlertsInputType : InputObjectGraphType {
    public AlertsInputType () {
      Name = "AlertsInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("Description");
      Field<IntGraphType> ("MetricThreshold");
      Field<IntGraphType> ("MeasurementIntervalValue");
      Field<StringGraphType> ("MeasurementIntervaUnitId");
      Field<IntervalUnitsInputType> ("IntervalUnits");
      Field<StringGraphType> ("RouteId");
      Field<RoutesInputType> ("Route");
      Field<BooleanGraphType> ("State");
      Field<StringGraphType> ("CodAlert");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("MetricTypeId");
      Field<StringGraphType> ("MetricConditionId");
    }
  }

}