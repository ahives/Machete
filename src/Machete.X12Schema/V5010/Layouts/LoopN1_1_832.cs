namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopN1_1_832 :
        X12Layout
    {
        Segment<N1> PartyIdentification { get; }
        
        SegmentList<N2> AdditionalNameInformation { get; }
        
        SegmentList<N3> PartyLocation { get; }
        
        Segment<N4> GeographicLocation { get; }
        
        SegmentList<REF> ReferenceInformation { get; }
        
        SegmentList<PKG> MarkingPackagingOrLoading { get; }
        
        SegmentList<PER> AdministrativeCommunicationsContact { get; }

        SegmentList<DTM> DateOrTimeReference { get; }
        
        SegmentList<MTX> Text { get; }
        
        Segment<SPI> SpecificationIdentifier { get; }
    }
}