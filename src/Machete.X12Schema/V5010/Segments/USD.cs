namespace Machete.X12Schema.V5010
{
    using X12;


    public interface USD :
        X12Segment
    {
        Value<string> RelationshipCode { get; }

        Value<string> AssignedIdentification { get; }

        Value<decimal> Rate { get; }

        Value<decimal> Percentage { get; }

        Value<string> CompositeUnitOfMeasure05 { get; }

        Value<decimal> Quantity06 { get; }

        Value<decimal> Quantity07 { get; }

        Value<decimal> MonetaryAmount { get; }

        Value<decimal> Amount { get; }

        Value<string> CompositeUnitOfMeasure10 { get; }

        Value<decimal> RangeMinimum { get; }
        
        Value<decimal> RangeMaximum { get; }
    }
}