namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class HL_IT1_ITA_811Map :
        X12LayoutMap<HL_IT1_ITA_811, X12Entity>
    {
        public HL_IT1_ITA_811Map()
        {
            Id = "Loop HL_IT1_ITA 811";
            Name = "Loop HL_IT1_ITA";
            
            Segment(x => x.AllowanceChargeOrService, 0);
            Segment(x => x.DateTimeReference, 1);
            Segment(x => x.TaxInformation, 2);
        }
    }
}