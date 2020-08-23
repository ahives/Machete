namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class HL_IT1_NM1_811Map :
        X12LayoutMap<HL_IT1_NM1_811, X12Entity>
    {
        public HL_IT1_NM1_811Map()
        {
            Id = "Loop HL_IT1_NM1 811";
            Name = "Loop HL_IT1_NM1";
            
            Segment(x => x.IndividualOrOrganizationName,0);
            Segment(x => x.AdditionalNameInformation,1);
            Segment(x => x.PartyLocation,2);
            Segment(x => x.GeographicInformation,3);
            Segment(x => x.AdministrativeCommunicationsContact,4);
            Segment(x => x.LocationIdComponent,5);
            Segment(x => x.DemographicInformation,6);
            Segment(x => x.ReferenceIdentification,7);
            Segment(x => x.PlaceLocationDescription,8);
        }
    }
}