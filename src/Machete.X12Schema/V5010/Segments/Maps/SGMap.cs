namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;
    using X12.Values.Converters;


    public class SGMap :
        X12SegmentMap<SG, X12Entity>
    {
        public SGMap()
        {
            Id = "SG";
            Name = "Shipment Status";
            
            Value(x => x.ShipmentStatusCode, 1, x => x.MinLength(1).MaxLength(2));
            Value(x => x.StatusReasonCode, 2, x => x.FixedLength(3));
            Value(x => x.CountryCode, 3, x => x.FixedLength(2));
            Value(x => x.Date, 4, x =>
            {
                x.FixedLength(8);
                x.Converter = X12ValueConverters.VariableDate;
            });
            Value(x => x.Time, 5, x =>
            {
                x.MinLength(4);
                x.MaxLength(8);
                x.Converter = X12ValueConverters.TimeWithSeconds;
            });
            Value(x => x.TimeCode, 6, x => x.FixedLength(2));
        }
    }
}