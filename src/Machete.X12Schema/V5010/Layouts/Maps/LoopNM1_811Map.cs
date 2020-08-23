namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopNM1_811Map :
        X12LayoutMap<LoopNM1_811, X12Entity>
    {
        public LoopNM1_811Map()
        {
            Id = "Loop NM1 811";
            Name = "Loop NM1";
            
            Segment(x => x.IndividualOrOrganizationName, 0);
            Segment(x => x.AdditionalNameInformation, 1);
            Segment(x => x.PartyLocation, 2);
            Segment(x => x.GeographicInformation, 3);
            Segment(x => x.ReferenceIdentification, 4);
            Segment(x => x.AdministrativeCommunicationsContact, 5);
            Segment(x => x.TaxInformation, 6);
            Segment(x => x.DemographicInformation, 7);
        }
    }
}