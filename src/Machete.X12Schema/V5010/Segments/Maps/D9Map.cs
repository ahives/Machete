namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class D9Map :
        X12SegmentMap<D9, X12Entity>
    {
        public D9Map()
        {
            Id = "D9";
            Name = "Destination Station";

            Value(x => x.FreightStationAccountingCode1, 1, x => x.MinLength(1).MaxLength(5));
            Value(x => x.CityName1, 2, x => x.MinLength(2).MaxLength(30).IsRequired());
            Value(x => x.StateOrProvinceCode1, 3, x => x.FixedLength(3).IsRequired());
            Value(x => x.CountryCode1, 4, x => x.MinLength(2).MaxLength(3));
            Value(x => x.FreightStationAccountingCode2, 5, x => x.MinLength(1).MaxLength(5));
            Value(x => x.CityName2, 6, x => x.MinLength(2).MaxLength(30));
            Value(x => x.StateOrProvinceCode2, 7, x => x.FixedLength(2));
            Value(x => x.StandardPointLocationCode1, 8, x => x.MinLength(6).MaxLength(9));
            Value(x => x.PostalCode1, 9, x => x.MinLength(3).MaxLength(15));
            Value(x => x.StandardPointLocationCode1, 10, x => x.MinLength(6).MaxLength(9));
            Value(x => x.PostalCode2, 11, x => x.MinLength(3).MaxLength(15));
            Value(x => x.CountryCode2, 12, x => x.MinLength(2).MaxLength(3));
        }
    }
}