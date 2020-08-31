namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopN1_1_813 :
        X12Layout
    {
        Segment<N1> PartyIdentification { get; }

        SegmentList<N2> AdditionalNameInformation { get; }

        SegmentList<IN2> IndividualNameStructureComponents { get; }

        SegmentList<N3> PartyLocation { get; }

        Segment<N4> GeographicLocation { get; }

        SegmentList<PER> AdministrativeCommunicationsContact { get; }
    }
}