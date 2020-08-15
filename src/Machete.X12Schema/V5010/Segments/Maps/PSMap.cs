namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class PSMap :
        X12SegmentMap<PS, X12Entity>
    {
        public PSMap()
        {
            Id = "PS";
            Name = "Protective Service Instructions";
            
            Value(x => x.ProtectiveServiceRuleCode, 1, x => x.MinLength(3).MaxLength(9).IsRequired());
            Value(x => x.ProtectiveServiceCode, 2, x => x.MinLength(1).MaxLength(4).IsRequired());
            Value(x => x.UnitBasisforMeasurementCode, 3, x => x.FixedLength(2));
            Value(x => x.Temperature1, 4, x => x.MinLength(1).MaxLength(4));
            Value(x => x.StandardCarrierAlphaCode, 5, x => x.MinLength(2).MaxLength(4));
            Value(x => x.FreightStationAlphaCode, 6, x => x.MinLength(1).MaxLength(5));
            Value(x => x.CityName, 7, x => x.MinLength(2).MaxLength(30));
            Value(x => x.StateOrProvinceCode, 8, x => x.FixedLength(2));
            Value(x => x.Weight, 9, x => x.MinLength(1).MaxLength(10));
            Value(x => x.PreCooledCode, 10, x => x.FixedLength(1));
            Value(x => x.YesNoConditionOrResponseCode1, 11, x => x.FixedLength(1));
            Value(x => x.YesNoConditionOrResponseCode2, 12, x => x.FixedLength(1));
            Value(x => x.YesNoConditionOrResponseCode3, 13, x => x.FixedLength(1));
            Value(x => x.YesNoConditionOrResponseCode2, 14, x => x.MinLength(1).MaxLength(4));
        }
    }
}