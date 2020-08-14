namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopLX_AMT :
        X12Layout
    {
        Segment<AMT> MonetaryAmountInformation { get; }
        
        Segment<DTM> DateOrTimeReference { get; }
    }
}