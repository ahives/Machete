namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopUSD_811Map :
        X12LayoutMap<LoopUSD_811, X12Entity>
    {
        public LoopUSD_811Map()
        {
            Id = "Loop_USD_811";
            Name = "Loop USD";
            
            Segment(x =>x.UsageSensitiveDetail, 0);
            Segment(x =>x.ServiceCharacteristicInformation, 1);
            Segment(x =>x.AllowanceChargeOrService, 2);
            Segment(x =>x.RatingFactors, 3);
            Layout(x =>x.LoopQty, 4);
        }
    }
}