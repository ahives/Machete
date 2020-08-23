namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class HL_IT1_QTY_811Map :
        X12LayoutMap<HL_IT1_QTY_811, X12Entity>
    {
        public HL_IT1_QTY_811Map()
        {
            Id = "Loop HL IT1 QTY 811";
            Name = "Loop HL_IT1_QTY";

            Segment(x => x.QuantityInformation, 0);
            Segment(x => x.ServiceCharacteristicInformation, 1);
        }
    }
}