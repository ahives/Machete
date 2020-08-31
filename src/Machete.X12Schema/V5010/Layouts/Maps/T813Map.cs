namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class T813Map :
        X12LayoutMap<T813, X12Entity>
    {
        public T813Map()
        {
            Id = "T813";
            Name = "813 Electronic Filing of Tax Return Data";

            Segment(x => x.FunctionalGroupHeader, 0);
            Segment(x => x.TransactionSetHeader, 1);
            Segment(x => x.BeginningTaxInformation, 2);
            Segment(x => x.DateTimeReference, 3);
            Segment(x => x.TaxInformationAndAmount, 4);
            Segment(x => x.ReferenceInformation, 5);
            Segment(x => x.Trace, 6);
            Segment(x => x.BeginningSegmentForPaymentOrderOrRemittanceAdvice, 7);
            Layout(x => x.LoopN1, 8);
            Layout(x => x.LoopTFS, 9);
            Segment(x => x.TransactionSetTrailer, 10);
            Segment(x => x.FunctionalGroupTrailer, 11);
        }
    }
}