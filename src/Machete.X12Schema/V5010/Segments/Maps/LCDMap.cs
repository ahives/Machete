namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LCDMap :
        X12SegmentMap<LCD, X12Entity>
    {
        public LCDMap()
        {
            Id = "LCD";
            Name = "Place/Location Description";

            Value(x => x.AssignedIdentification, 1, x=>x.MinLength(1).MaxLength(20));
            Value(x => x.EntityIdentifierCode, 2, x=>x.MinLength(2).MaxLength(3));
            Value(x => x.ActionCode, 3, x=>x.MinLength(1).MaxLength(2));
            Value(x => x.Date, 4, x=>x.FixedLength(8));
            Value(x => x.IdentifierCodeQualifier, 5, x=>x.MinLength(1).MaxLength(2));
            Value(x => x.IdentifierCode, 6, x=>x.MinLength(2).MaxLength(80));
        }
    }
}