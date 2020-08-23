namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopITA_1_811Map :
        X12LayoutMap<LoopITA_1_811, X12Entity>
    {
        public LoopITA_1_811Map()
        {
            Id = "Loop ITA 1 811";
            Name = "Loop ITA";
            
            Segment(x => x.AllowanceChargeOrService, 0);
            Segment(x => x.DateOrTimeReference, 1);
            Segment(x => x.TaxInformation, 2);
        }
    }
}