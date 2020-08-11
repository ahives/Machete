namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopHL_811 : 
        X12Layout
    {
        Segment<HL> HierchicalLevel { get;  }

        LayoutList<LoopLX_811> LoopLX { get; }
    }
}