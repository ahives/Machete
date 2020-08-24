namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopUSD_811 :
        X12Layout
    {
        Segment<USD> UsageSensitiveDetail { get; }

        SegmentList<SI> ServiceCharacteristicInformation { get; }

        SegmentList<ITA> AllowanceChargeOrService { get; }

        SegmentList<TRF> RatingFactors { get; }

        LayoutList<LoopQTY_811> LoopQty { get; }
    }
}