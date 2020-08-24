namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopLQ_811Map :
        X12LayoutMap<LoopLQ_811, X12Entity>
    {
        public LoopLQ_811Map()
        {
            Id = "Loop LQ 811";
            Name = "Loop LQ";

            Segment(x => x.IndustryCodeIdentification, 0);
            Segment(x => x.MonetaryAmountInformation, 1);
            Segment(x => x.PercentAmounts, 2);
        }
    }
}