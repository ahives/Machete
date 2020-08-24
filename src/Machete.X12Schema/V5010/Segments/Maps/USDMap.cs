namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class USDMap :
        X12SegmentMap<USD, X12Entity>
    {
        public USDMap()
        {
            Id = "USD";
            Name = "Usage-Sensitive Detail";

            Value(x => x.RelationshipCode, 1, x=>x.FixedLength(1));
            Value(x => x.AssignedIdentification, 2, x=>x.MinLength(1).MaxLength(20));
            Value(x => x.Rate, 3, x=>x.MinLength(1).MaxLength(9));
            Value(x => x.Percentage, 4, x=>x.MinLength(1).MaxLength(10));
            
            // TODO - what is the length???
            Value(x => x.CompositeUnitOfMeasure05, 5, x=>x.MinLength(1).MaxLength(255));
            Value(x => x.Quantity06, 6, x=>x.MinLength(1).MaxLength(15));
            Value(x => x.Quantity07, 7, x=>x.MinLength(1).MaxLength(15));
            Value(x => x.MonetaryAmount, 8, x=>x.MinLength(1).MaxLength(18));
            Value(x => x.Amount, 9, x=>x.MinLength(1).MaxLength(15));

            // TODO - what is the length???
            Value(x => x.CompositeUnitOfMeasure10, 10, x=>x.MinLength(1).MaxLength(255));
            Value(x => x.RangeMinimum, 11, x=>x.MinLength(1).MaxLength(20));
            Value(x => x.RangeMaximum, 12, x=>x.MinLength(1).MaxLength(20));
        }
    }
}