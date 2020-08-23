namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopHL_811 :
        X12Layout
    {
        Segment<HL> HierchicalLevel { get; }

        LayoutList<LoopLX_811> LoopLX { get; }

        Layout<LoopNM1_811> LoopNM1 { get; }

        LayoutList<LoopITA_1_811> LoopITA { get; }

        LayoutList<LoopIT1_811> LoopIT1 { get; }
    }
}