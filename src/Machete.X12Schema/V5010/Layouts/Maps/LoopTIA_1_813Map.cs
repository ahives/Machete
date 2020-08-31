namespace Machete.X12Schema.V5010.Maps
{

    using X12;
    using X12.Configuration;


    public class LoopTIA_1_813Map :
        X12LayoutMap<LoopTIA_813, X12Entity>
    {
        public LoopTIA_1_813Map()
        {
            Id = "Loop_TIA_1_813";
            Name = "Loop TIA";

            Segment(x => x.TaxInformationAndAmount, 0);
            Segment(x => x.DateOrTimeReference, 1);
            Segment(x => x.MessageText, 2);
        }
    }
}