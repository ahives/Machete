namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopN1_2_850 :
        X12Layout
    {
        Segment<N1> PartyIdentification { get; }
        
        SegmentList<N2> AdditionalNameInformation { get; }
        
        SegmentList<N3> PartyLocation { get; }
        
        Segment<N4> GeographicLocation { get; }
        
        SegmentList<REF> ReferenceInformation { get; }
        
        Segment<G61> Contact { get; }
        
        SegmentList<MTX> Text { get; }
    }
}