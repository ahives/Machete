namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopHL_811Map :
        X12LayoutMap<LoopHL_811, X12Entity>
    {
        public LoopHL_811Map()
        {
            Id = "Loop HL 811";
            Name = "Loop HL";

            Segment(x => x.HierchicalLevel, 0);
            Layout(x => x.LoopLX, 1);
            Layout(x => x.LoopNM1, 2);
            Layout(x => x.LoopITA, 3);
            Layout(x => x.LoopIT1, 4);
            Layout(x => x.LoopSLN, 5);
            Layout(x => x.LoopTCD, 6);
            Layout(x => x.LoopUSD, 7);
            Layout(x => x.LoopIII, 8);
            Layout(x => x.LoopFA1, 9);
        }
    }
}