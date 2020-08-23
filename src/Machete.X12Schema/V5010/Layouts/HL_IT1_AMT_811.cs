namespace Machete.X12Schema.V5010
{
    using X12;


    public interface HL_IT1_AMT_811 :
        X12Layout
    {
        Segment<AMT> MonetaryAmountInformation { get; }

        Segment<CUR> Currency { get; }
    }
}