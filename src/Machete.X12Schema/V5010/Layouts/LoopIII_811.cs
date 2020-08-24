namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopIII_811 :
        X12Layout
    {
        Segment<III> Information { get; }

        SegmentList<DTP> DateOrTimeOrPeriod { get; }

        SegmentList<AMT> MonetaryAmountInformation { get; }

        SegmentList<PCT> PercentAmounts { get; }

        LayoutList<LoopLQ_811> LoopLQ { get; }
    }
}