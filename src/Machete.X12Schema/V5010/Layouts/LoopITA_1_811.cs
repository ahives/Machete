namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopITA_1_811 :
        X12Layout
    {
        Segment<ITA> AllowanceChargeOrService { get; }
        Segment<DTM> DateOrTimeReference { get; }
        SegmentList<TXI> TaxInformation { get; }
    }
}