namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class T811Map :
        X12LayoutMap<T811, X12Entity>
    {
        public T811Map()
        {
            Id = "T811";
            Name = "Consolidated Service Invoice/Statement";

            Segment(x => x.FunctionalGroupHeader, 0);
            Segment(x => x.TransactionSetHeader, 1);
            Segment(x => x.BeginningSegmentForInvoice, 2);
            Segment(x => x.SpecialInstructions, 3);
            Segment(x => x.Currency, 4);
            Segment(x => x.ReferenceInformation, 5);
            Segment(x => x.AdministrativeCommunicationsContact, 6);
            Segment(x => x.TermsOfSale, 7);
            Segment(x => x.DateOrTimeReference, 8);
            Segment(x => x.TaxInformation, 9);
            Layout(x => x.LoopN1, 10);
            Layout(x => x.LoopFA1, 11);
            Layout(x => x.LoopHL, 12);
            Segment(x=> x.TotalMonetaryValueSummary, 13);
            Layout(x => x.LoopITA,14);
            Layout(x => x.LoopBAL,15);
            Layout(x => x.LoopN1_2,16);
            Segment(x => x.TransactionTotals, 17);
            Segment(x => x.TransactionSetTrailer, 18);
            Segment(x => x.FunctionalGroupTrailer, 19);
        }
    }
}