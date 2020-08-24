namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class TCDMap :
        X12SegmentMap<TCD, X12Entity>
    {
        public TCDMap()
        {
            Id = "TCD";
            Name = "Itemized Call Detail";

            Value(x=> x.AssignedIdentification, 1, x=> x.MinLength(1).MaxLength(20));
            Value(x=> x.Date, 2, x=> x.FixedLength(8));
            Value(x=> x.Time, 3, x=> x.MinLength(4).MaxLength(8));
            Value(x => x.LocationQualifier04, 4, x=> x.MinLength(1).MaxLength(2));
            Value(x => x.LocationIdentifier05, 5, x=> x.MinLength(1).MaxLength(30));
            Value(x => x.StateOrProvinceCode06, 6, x=> x.FixedLength(2));
            Value(x => x.LocationQualifier07, 7, x=> x.MinLength(1).MaxLength(2));
            Value(x => x.LocationIdentifier08, 8, x=> x.MinLength(1).MaxLength(30));
            Value(x => x.StateOrProvinceCode09, 9, x=> x.FixedLength(2));
            Value(x => x.MeasurementValue10, 10, x=> x.MinLength(1).MaxLength(20));
            Value(x => x.MeasurementValue11, 11, x=> x.MinLength(1).MaxLength(20));
            Value(x => x.MonetaryAmount12, 12, x=> x.MinLength(1).MaxLength(18));
            Value(x => x.MonetaryAmount13, 13, x=> x.MinLength(1).MaxLength(18));
            Value(x => x.MonetaryAmount14, 14, x=> x.MinLength(1).MaxLength(18));
            Value(x => x.MonetaryAmount15, 15, x=> x.MinLength(1).MaxLength(18));
            Value(x => x.RelationshipCode, 16, x=> x.FixedLength(1));
        }
    }
}