namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class T827Map :
        X12LayoutMap<T827, X12Entity>
    {
        public T827Map()
        {
            Id = "T827";
            Name = "827 Financial Return Notice";

            Segment(x => x.FunctionalGroupHeader, 0);
            Segment(x => x.TransactionSetHeader, 1);
            Segment(x => x.FinancialReturn, 2);
            Segment(x => x.Currency, 3);
            Segment(x => x.Trace, 4);
            Segment(x => x.ReferenceInformation, 5);
            Segment(x => x.DateOrTimeReference, 6);
            Layout(x => x.LoopNM1, 7);
            Segment(x => x.TransactionSetTrailer, 8);
            Segment(x => x.FunctionalGroupTrailer, 9);
        }
    }
}