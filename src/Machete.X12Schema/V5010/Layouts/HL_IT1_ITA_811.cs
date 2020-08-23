namespace Machete.X12Schema.V5010
{
    using X12;


    public interface HL_IT1_ITA_811 :
        X12Layout
    {
        Segment<ITA> AllowanceChargeOrService { get; }

        Segment<DTM> DateTimeReference { get; }

        SegmentList<TXI> TaxInformation { get; }
    }
}