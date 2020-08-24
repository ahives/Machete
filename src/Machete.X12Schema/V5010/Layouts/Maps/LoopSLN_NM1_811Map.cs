namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopSLN_NM1_811Map :
        X12LayoutMap<LoopSLN_NM1_811, X12Entity>
    {
        public LoopSLN_NM1_811Map()
        {
            Id = "LoopSLN_NM1_811";
            Name = "Loop SLN_NM1";

            Segment(x => x.IndividualOrOrganizationName, 0);
            Segment(x => x.AdditionalNameInformation, 1);
            Segment(x => x.PartyLocation, 2);
            Segment(x => x.GeographicInformation, 3);
            Segment(x => x.ReferenceIdentification, 4);
            Segment(x => x.AdministrativeCommunicationsContact, 5);
            Segment(x => x.DemographicInformation, 6);
        }
    }
}