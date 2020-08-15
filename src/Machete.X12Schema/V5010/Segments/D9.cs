namespace Machete.X12Schema.V5010
{
    using X12;


    public interface D9 :
        X12Segment
    {
        Value<string> FreightStationAccountingCode1 { get; }
        
        Value<string> CityName1 { get; }
        
        Value<string> StateOrProvinceCode1 { get; }
        
        Value<string> CountryCode1 { get; }
        
        Value<string> FreightStationAccountingCode2 { get; }
        
        Value<string> CityName2 { get; }
        
        Value<string> StateOrProvinceCode2 { get; }
        
        Value<string> StandardPointLocationCode1 { get; }
        
        Value<string> PostalCode1 { get; }
        
        Value<string> StandardPointLocationCode2 { get; }
        
        Value<string> PostalCode2 { get; }
        
        Value<string> CountryCode2 { get; }
    }
}