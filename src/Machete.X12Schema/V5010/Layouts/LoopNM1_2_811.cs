namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopNM1_2_811 :
        X12Layout
    {
        Segment<NM1> IndividualOrOrganizationName { get; }

        SegmentList<N2> AdditionalNameInformation { get; }

        SegmentList<N3> PartyLocation { get; }

        Segment<N4> GeographicLocation { get; }

        SegmentList<PER> AdministrativeCommunicationsContact { get; }

        SegmentList<NX2> LocationIdComponent { get; }

        Segment<DMG> DemographicInformation { get; }

        SegmentList<REF> ReferenceInformation { get; }

        SegmentList<LCD> PlaceLocationDescription { get; }
    }
}