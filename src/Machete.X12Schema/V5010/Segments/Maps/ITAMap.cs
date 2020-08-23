namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class ITAMap :
        X12SegmentMap<ITA, X12Entity>
    {
        public ITAMap()
        {
            Id = "ITA";
            Name = "AllowanceChargeOrService";

            Value(x => x.AllowanceOrChargeIndicator, 1, x => x.FixedLength(1).IsRequired());
            Value(x => x.AgencyQualifierCode, 2, x => x.FixedLength(2));
            Value(x => x.SpecialServicesCode, 3, x => x.MinLength(2).MaxLength(10));
            Value(x => x.AllowanceOrChargeMethodOfHandlingCode, 4, x => x.FixedLength(2).IsRequired());
            Value(x => x.AllowanceOrChargeNumber, 5, x => x.MinLength(1).MaxLength(16));
            Value(x => x.AllowanceOrChargeRate, 6, x => x.MinLength(1).MaxLength(15));
            Value(x => x.AllowanceOrChargeTotalAmount, 7, x => x.MinLength(1).MaxLength(15));
            Value(x => x.AllowanceChargePercentQualifier, 8, x => x.FixedLength(1));
            Value(x => x.PercentDecimalFormat, 9, x => x.MinLength(1).MaxLength(6));
            Value(x => x.Quantity10, 10, x => x.MinLength(1).MaxLength(15));
            Value(x => x.UnitOrBasisForMeasurementCode11, 11, x => x.FixedLength(2));
            Value(x => x.Quantity12, 12, x => x.MinLength(1).MaxLength(15));
            Value(x => x.Description, 13, x => x.MinLength(1).MaxLength(80));
            Value(x => x.SpecialChargeOrAllowanceCode, 14, x => x.FixedLength(3));
            Value(x => x.SourceSubqualifier, 15, x => x.MinLength(1).MaxLength(15));
            Value(x => x.RelationshipCode, 16, x => x.FixedLength(1));
            Value(x => x.UnitOrBasisForMeasurementCode17, 17, x => x.FixedLength(2));
        }
    }
}