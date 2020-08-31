namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopFGS_813Map :
        X12LayoutMap<LoopFGS_813, X12Entity>
    {
        public LoopFGS_813Map()
        {
            Id = "Loop_FGS_813";
            Name = "loop FGS";

            Segment(x => x.FormGroup, 0);
            Segment(x => x.ReferenceInformation, 1);
            Segment(x => x.DateOrTimeReference, 2);
            Layout(x => x.LoopN1, 3);
            Layout(x => x.LoopTIA, 4);
        }
    }
}