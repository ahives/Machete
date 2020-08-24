namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopTCD_811Map :
        X12LayoutMap<LoopTCD_811, X12Entity>
    {
        public LoopTCD_811Map()
        {
            Id = "Loop TCD 811";
            Name = "Loop TCD";

            Segment(x => x.ItemizedCallDetail, 0);
            Segment(x => x.ServiceCharacteristicInformation, 1);
            Segment(x => x.TaxInformation, 2);
            Segment(x => x.AllowanceChargeOrService, 3);
            Layout(x => x.LoopQty, 4);
        }
    }
}