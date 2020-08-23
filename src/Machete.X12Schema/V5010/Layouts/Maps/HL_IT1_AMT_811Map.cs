namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class HL_IT1_AMT_811Map :
        X12LayoutMap<HL_IT1_AMT_811, X12Entity>
    {
        public HL_IT1_AMT_811Map()
        {
            Id = "Loop HL IT1 AMT 811";
            Name = "Loop HL IT1 AMT";
            
            Segment(x => x.MonetaryAmountInformation, 0);
            Segment(x => x.Currency, 1);
            Segment(x => x.Currency, 1);
        }
    }
}