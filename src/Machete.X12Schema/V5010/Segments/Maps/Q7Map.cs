namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class Q7Map :
        X12SegmentMap<Q7, X12Entity>
    {
        public Q7Map()
        {
            Id = "Q7";
            Name = "Lading Exception Status";
            
            Value(x => x.LadingExceptionCode, 1, x=>x.FixedLength(1).IsRequired());
            Value(x => x.PackagingFormCode, 2, x=>x.FixedLength(3).IsRequired());
            Value(x => x.LadingQuantity, 3, x=>x.MinLength(1).MaxLength(7));

        }
    }
}