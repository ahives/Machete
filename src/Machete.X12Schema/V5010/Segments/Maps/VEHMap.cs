namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class VEHMap :
        X12SegmentMap<VEH, X12Entity>
    {
        public VEHMap()
        {
            Id = "VEH";
            Name = "VEH Information";
            
            Value(x => x.AssignedNumber, 1, x=>x.MinLength(1).MaxLength(6));
            Value(x => x.VehicleIdentificationNumber, 2, x=>x.MinLength(1).MaxLength(30));
            Value(x => x.Year, 3, x=>x.FixedLength(4));
            Value(x => x.AgencyQualifierCode, 4, x => x.FixedLength(2));
            Value(x => x.ReferenceIdentification1, 5, x => x.MinLength(1).MaxLength(50));
            Value(x => x.ReferenceIdentification2, 6, x => x.MinLength(1).MaxLength(50));
            Value(x => x.ReferenceIdentification3, 7, x => x.MinLength(1).MaxLength(50));
            Value(x => x.Length, 8, x => x.MinLength(1).MaxLength(8));
            Value(x => x.ReferenceIdentification4, 9, x => x.MinLength(1).MaxLength(50));
            Value(x => x.StateOrProvinceCode, 10, x => x.FixedLength(2));
            Value(x => x.LocationIdentifier, 11, x => x.MinLength(1).MaxLength(30));
            Value(x => x.YesOrNoResponseCode1, 12, x => x.MinLength(1).MaxLength(30));
            Value(x => x.Amount1, 13, x => x.MinLength(1).MaxLength(15));
            Value(x => x.YesOrNoResponseCode2, 14, x => x.MinLength(1).MaxLength(30));
            Value(x => x.Amount2, 15, x => x.MinLength(1).MaxLength(15));
            Value(x => x.ActionCode, 16, x => x.MinLength(1).MaxLength(2));
            Value(x => x.CountryCode1, 17, x => x.MinLength(2).MaxLength(3));
            Value(x => x.Name, 18, x => x.MinLength(1).MaxLength(60));
            Value(x => x.CountryCode2, 19, x => x.MinLength(2).MaxLength(3));
        }
    }
}