namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;

ß
    public class LoopN1_1_811Map :
        X12LayoutMap<LoopN1_1_811, X12Entity>
    {
        public LoopN1_1_811Map()
        {
            Id = "Loop_N1_811";
            Name = "Loop N1";

            Segment(x => x.PartyIdentification, 0);
            Segment(x => x.AdditionalNameInformation, 1);
            Segment(x => x.PartyLocation, 2);
            Segment(x => x.GeographicInformation, 3);
            Segment(x => x.ReferenceInformation, 4);
            Segment(x => x.AdministrativeCommunicationsContact, 5);
            Segment(x => x.DemographicInformation, 7);
        }
    }
}