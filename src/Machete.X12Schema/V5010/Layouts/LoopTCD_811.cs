namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopTCD_811 :
        X12Layout
    {
        Segment<TCD> ItemizedCallDetail { get; }

        SegmentList<SI> ServiceCharacteristicInformation { get; }

        SegmentList<TXI> TaxInformation { get; }

        SegmentList<ITA> AllowanceChargeOrService { get; }

        LayoutList<LoopQTY_811> LoopQty { get; }
    }
}