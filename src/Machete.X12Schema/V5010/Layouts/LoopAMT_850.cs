namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopAMT_850 :
        X12Layout
    {
        Segment<AMT> MonetaryAmountInformation { get; }
        
        SegmentList<REF> ReferenceInformation { get; }
        
        Segment<DTM> DateOrTimeReference { get; }
        
        SegmentList<PCT> PercentAmounts { get; }
        
        LayoutList<LoopFA1_850> LoopFA1 { get; }
    }
}