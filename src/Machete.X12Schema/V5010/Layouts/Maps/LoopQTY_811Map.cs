namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopQTY_811Map :
        X12LayoutMap<LoopQTY_811, X12Entity>
    {
        public LoopQTY_811Map()
        {
            Id = "Loop QTY 811";
            Name = "Loop QTY";
            
            Segment(x => x.Quantity, 0);
            Segment(x => x.ServiceCharacteristicIdentification, 1);
        }
    }
}