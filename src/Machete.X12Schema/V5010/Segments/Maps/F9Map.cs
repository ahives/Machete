namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class F9Map :
        X12SegmentMap<F9, X12Entity>
    {
        public F9Map()
        {
            Id = "F9";
            Name = "Detail - Supporting Evidence for Claim";
            
            Value( x => x.Quantity, 1, x=> x.MinLength(1).MaxLength(15).IsRequired());
            
            Value( x => x.UnitOfMeasureCode, 2, x=> x.FixedLength(2).IsRequired());
            
            Value( x => x.NatureOfClaimCode, 3, x=> x.FixedLength(2).IsRequired());
            
            Value( x => x.Amount1, 4, x=> x.MinLength(1).MaxLength(15).IsRequired());
            
            Value( x => x.Amount2, 5, x=> x.MinLength(1).MaxLength(15).IsRequired());
            
            Value( x => x.Description, 6, x=> x.MinLength(1).MaxLength(80));
            
            Value( x => x.LadingDescription, 7, x=> x.MinLength(1).MaxLength(50));
            
            Value( x => x.ReferenceIdentifierQualifier1, 8, x=> x.MinLength(2).MaxLength(3));
            
            Value( x => x.ReferenceIdentification1, 9, x=> x.MinLength(1).MaxLength(50));
            
            Value( x => x.ReferenceIdentifierQualifier2, 10, x=> x.MinLength(2).MaxLength(3));
            
            Value( x => x.ReferenceIdentification2, 11, x=> x.MinLength(1).MaxLength(50));
            
            Value( x => x.LadingLineItemNumber, 12, x=> x.MinLength(1).MaxLength(3));
        }
    }
}