namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class B10Map :
        X12SegmentMap<B10, X12Entity>
    {
        public B10Map()
        {
            Id = "B10";
            Name = "Beginning Segment for Transportation Carrier Shipment Status Message";
            Value(x => x.ReferenceIdentification1, 1, x=> x.MinLength(1).MaxLength(50));
            Value(x => x.ShipmentIdentificationNumber, 2, x=> x.MinLength(1).MaxLength(30));
            Value(x => x.StandardCarrierAlphaCode, 3, x=> x.MinLength(2).MaxLength(4).IsRequired());
            Value(x => x.InquiryRequestNumber, 4, x=> x.MinLength(1).MaxLength(3));
            Value(x => x.ReferenceIdentificationQualifier, 5, x=> x.MinLength(2).MaxLength(3));
            Value(x => x.ReferenceIdentification2, 6, x=> x.MinLength(1).MaxLength(50));
            Value(x => x.YesNoConditionOrResponseCode, 7, x=> x.FixedLength(1));
            Value(x => x.Date, 8, x=> x.FixedLength(8));
            Value(x => x.Time, 9, x=> x.MinLength(4).MaxLength(8));


        }
    }
}