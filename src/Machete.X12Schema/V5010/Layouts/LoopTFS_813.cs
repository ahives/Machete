namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopTFS_813 :
        X12Layout
    {
        Segment<TFS> TaxForm { get; }

        SegmentList<TFS> ReferenceInformation { get; }

        SegmentList<DTM> DateTimeReference { get; }

        SegmentList<MSG> MessageText { get; }

        LayoutList<LoopN1_2_813> LoopN1 { get; }

        LayoutList<LoopTIA_1_813> LoopTIA { get; }

        LayoutList<LoopFGS_813> LoopFGS { get; }

    }
}