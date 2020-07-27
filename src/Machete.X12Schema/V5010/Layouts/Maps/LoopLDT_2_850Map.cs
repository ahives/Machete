namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopLDT_2_850Map :
        X12LayoutMap<LoopLDT_2_850, X12Entity>
    {
        public LoopLDT_2_850Map()
        {
            Id = "Loop_LDT_2_850";
            Name = "Loop LDT";
            
            Segment(x => x.LeadTime, 0);
            Segment(x => x.MarksAndNumbersInformation, 1);
            Segment(x => x.Quantity, 2);
            Segment(x => x.MessageText, 3);
            Segment(x => x.ReferenceIdentification, 4);
        }
    }
}