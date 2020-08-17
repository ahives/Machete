namespace Machete.X12Schema.V5010
{
    using X12;


    public interface VEH :
        X12Segment
    {
        Value<int> AssignedNumber { get; }
        
        Value<string> VehicleIdentificationNumber { get; }
        
        Value<int> Year { get; }
        
        Value<string> AgencyQualifierCode { get; }
        
        Value<string> ReferenceIdentification1 { get; }
        
        Value<string> ReferenceIdentification2 { get; }
        
        Value<string> ReferenceIdentification3 { get; }
        
        Value<decimal> Length { get; }
        
        Value<string> ReferenceIdentification4 { get; }
        
        Value<string> StateOrProvinceCode { get; }
        
        Value<string> LocationIdentifier { get; }
        
        Value<string> YesOrNoResponseCode1 { get; }
        
        Value<decimal> Amount1 { get; }
        
        Value<string> YesOrNoResponseCode2 { get; }
        
        Value<decimal> Amount2 { get; }
        
        Value<string> ActionCode { get; }
        
        Value<string> CountryCode1 { get; }
        
        Value<string> Name { get; }
        
        Value<string> CountryCode2 { get; }
    }
}