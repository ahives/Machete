namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopLH1_301Map :
        X12LayoutMap<LoopLH1_301, X12Entity>
    {
        public LoopLH1_301Map()
        {
            Id = "Loop_LH1_301";
            Name = "Loop LH1";
            
            Segment(x => x.HazardousIdentificationInformation, 0);
            Segment(x => x.HazardousClassificationInformation, 1);
            Segment(x => x.HazardousMaterialShippingName, 2);
            Segment(x => x.FreeformHazardousMaterialInformation, 3);
            Segment(x => x.EPARequiredData, 4);
            Segment(x => x.CanadianDangerousRequirements, 5);
            Segment(x => x.TransborderDangerousRequirements, 6);
            Segment(x => x.HazardousMaterialIdentifyingReferenceNumbers, 7);
            Segment(x => x.AdministrativeCommunicationsContact, 8);
        }
    }
}