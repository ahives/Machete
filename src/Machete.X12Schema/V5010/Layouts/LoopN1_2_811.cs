namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopN1_2_811 :
        X12Layout
    {
        Segment<N1> Name { get; }
        
        LayoutList<LoopBAL_2_811> LoopBAL { get; }
        
        LayoutList<LoopITA_3_811> LoopITA { get; }
        
        LayoutList<LoopLX_2_811> LoopLX { get; }
    }
}