namespace Machete.X12Schema.V5010
{
    using X12;


    public interface TRF :
        X12Segment
    {
        Value<string> QuantityQualifier { get; }

        Value<string> CompositeUnitOfMeasure02 { get; }

        Value<decimal> Quantity03 { get; }

        Value<string> CompositeUnitOfMeasure04 { get; }

        Value<decimal> Quantity05 { get; }
    }
}