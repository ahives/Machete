namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopNM1_827Map :
        X12LayoutMap<LoopNM1_827, X12Entity>
    {
        public LoopNM1_827Map()
        {
            Id = "Loop_NM1_827";
            Name = "Loop NM1";

            Segment(x => x.IndividualOrOrganizationName, 0);
            Segment(x => x.AdditionalNameInformation, 1);
            Segment(x => x.AddressInformation, 2);
            Segment(x => x.GeographicInformation, 3);
            Segment(x => x.ReferenceIdentification, 4);
            Segment(x => x.AdministrativeCommunicationsContact, 5);
        }
    }
}