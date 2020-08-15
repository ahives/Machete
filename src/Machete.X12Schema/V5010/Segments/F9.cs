namespace Machete.X12Schema.V5010
{
    using X12;


    public interface F9 :
        X12Segment
    {
        Value<decimal> Quantity { get; }
        
        Value<string> UnitOfMeasureCode { get; }
        
        Value<string> NatureOfClaimCode { get; }
        
        Value<decimal> Amount1 { get; }
        
        Value<decimal> Amount2 { get; }
        
        Value<string> Description { get; }
        
        Value<string> LadingDescription { get; }
        
        Value<string> ReferenceIdentifierQualifier1 { get; }
        
        Value<string> ReferenceIdentification1 { get; }
        
        Value<string> ReferenceIdentifierQualifier2 { get; }
        
        Value<string> ReferenceIdentification2 { get; }
        
        Value<int> LadingLineItemNumber { get; }
    }
}