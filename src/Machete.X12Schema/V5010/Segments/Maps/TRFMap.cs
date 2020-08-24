namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class TRFMap :
        X12SegmentMap<TRF, X12Entity>
    {
        public TRFMap()
        {
            Id = "TRF";
            Name = "Rating Factors";

            Value(x => x.QuantityQualifier, 1, x => x.FixedLength(2));
            // TODO - what is the length
            Value(x => x.CompositeUnitOfMeasure02, 2, x => x.MinLength(1).MaxLength(255));
            Value(x => x.Quantity03, 1, x => x.MinLength(1).MaxLength(15));

            // TODO - what is the length
            Value(x => x.CompositeUnitOfMeasure04, 2, x => x.MinLength(1).MaxLength(255));
            Value(x => x.Quantity05, 1, x => x.MinLength(1).MaxLength(15));

        }
    }
}