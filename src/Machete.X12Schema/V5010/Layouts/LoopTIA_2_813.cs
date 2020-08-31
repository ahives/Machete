namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopTIA_2_813 :
        X12Layout
    {
        Segment<TIA> TaxInformationAndAmount { get; }

        SegmentList<DTM> DateTimeReference { get; }

        SegmentList<MSG > MessageText { get; }
    }
}