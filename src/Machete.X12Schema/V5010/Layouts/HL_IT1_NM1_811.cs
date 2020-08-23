namespace Machete.X12Schema.V5010
{
    using X12;


    public interface HL_IT1_NM1_811 :
        X12Layout
    {
        Segment<NM1> IndividualOrOrganizationName { get; }

        SegmentList<N2> AdditionalNameInformation { get; }

        SegmentList<N3> PartyLocation { get; }

        Segment<N4> GeographicInformation { get; }

        SegmentList<PER> AdministrativeCommunicationsContact { get; }

        SegmentList<NX2> LocationIdComponent { get; }

        Segment<DMG> DemographicInformation { get; }

        SegmentList<REF> ReferenceIdentification { get; }

        SegmentList<LCD> PlaceLocationDescription { get; }
    }
}