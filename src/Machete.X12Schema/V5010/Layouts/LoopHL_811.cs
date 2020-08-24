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

        LayoutList<LoopSLN_811> LoopSLN { get; }

        LayoutList<LoopTCD_811> LoopTCD { get; }

        LayoutList<LoopUSD_811> LoopUSD { get; }

        LayoutList<LoopIII_811> LoopIII { get; }

        LayoutList<LoopFA1_811> LoopFA1 { get; }
    }
}