namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class T894Map :
        X12LayoutMap<T894, X12Entity>
    {
        public T894Map()
        {
            Id = "T894";
            Name = "894 Delivery/Return Base Record";
            
            Segment(x => x.FunctionalGroupHeader, 0);
            Segment(x => x.TransactionSetHeader, 1);
            Segment(x => x.DeliveryOrReturnBaseRecordIdentifier, 2);
            Segment(x => x.ExtendedReferenceInformation, 3);
            Segment(x => x.LoopHeader, 4);
            Layout(x => x.Loop0100, 5);
            Segment(x => x.LoopTrailer, 6);
            Segment(x => x.AllowanceOrCharge, 7);
            Segment(x => x.TermsOfSale, 8);
            Segment(x => x.DeliveryOrReturnBaseRecordOfTotals, 9);
            Segment(x => x.SignatureIdentification, 10);
            Segment(x => x.RecordIntegrityCheck, 11);
            Segment(x => x.TransactionSetTrailer, 14);
            Segment(x => x.FunctionalGroupTrailer, 15);
        }
    }
}