namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopFGS_813 :
        X12Layout
    {
        Segment<FGS> FormGroup { get; }

        SegmentList<REF> ReferenceInformation { get; }

        SegmentList<DTM> DateOrTimeReference { get; }

        LayoutList<LoopN1_2_813> LoopN1 { get; }

        LayoutList<LoopTIA_813> LoopTIA { get; }
    }
}