namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopBAL_811 :
        X12Layout
    {
        Segment<BAL> BalanceDetail { get; }
        
        Segment<DTM> DateTimeReference { get; }
    }
}