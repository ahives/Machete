namespace Machete.X12Schema.V5010
{
    using X12;


    public interface PS :
        X12Segment
    {
        Value<string> ProtectiveServiceRuleCode { get; }
        
        Value<string> ProtectiveServiceCode { get; }
        
        Value<string> UnitBasisforMeasurementCode { get; }
        
        Value<decimal> Temperature1 { get; }
        
        Value<string> StandardCarrierAlphaCode { get; }
        
        Value<string> FreightStationAlphaCode { get; }
        
        Value<string> CityName { get; }
        
        Value<string> StateOrProvinceCode { get; }
        
        Value<decimal> Weight { get; }
        
        Value<string> PreCooledCode { get; }
        
        Value<string> YesNoConditionOrResponseCode1 { get; }
        
        Value<string> YesNoConditionOrResponseCode2 { get; }
        
        Value<string> YesNoConditionOrResponseCode3 { get; }
        
        Value<decimal> Temperature2 { get; }
    }
}