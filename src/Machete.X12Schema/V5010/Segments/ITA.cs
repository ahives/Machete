namespace Machete.X12Schema.V5010
{
    using X12;


    public interface ITA :
        X12Segment
    {
        Value<string> AllowanceOrChargeIndicator { get; }

        Value<string> AgencyQualifierCode { get; }

        Value<string> SpecialServicesCode { get; }

        Value<string> AllowanceOrChargeMethodOfHandlingCode { get; }

        Value<string> AllowanceOrChargeNumber { get; }

        Value<decimal> AllowanceOrChargeRate { get; }

        Value<decimal> AllowanceOrChargeTotalAmount { get; }

        Value<string> AllowanceChargePercentQualifier { get; }

        Value<decimal> PercentDecimalFormat { get; }

        Value<decimal> Quantity10 { get; }

        Value<string> UnitOrBasisForMeasurementCode11 { get; }

        Value<decimal> Quantity12 { get; }

        Value<string> Description { get; }

        Value<string> SpecialChargeOrAllowanceCode { get; }

        Value<string> SourceSubqualifier { get; }

        Value<string> RelationshipCode { get; }

        Value<string> UnitOrBasisForMeasurementCode17 { get; }
    }
}