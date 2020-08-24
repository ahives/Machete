namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopLQ_811 : X12Layout
    {
        Segment<LQ> IndustryCodeIdentification { get; }
        Segment<AMT> MonetaryAmountInformation { get; }
        Segment<PCT> PercentAmounts { get; }
    }
}