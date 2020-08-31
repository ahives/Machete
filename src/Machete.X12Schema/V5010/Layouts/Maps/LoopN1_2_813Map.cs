namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopN1_2_813Map :
        X12LayoutMap<LoopN1_2_813, X12Entity>
    {
        public LoopN1_2_813Map()
        {
            Id = "Loop_N1_2_813";
            Name = "Loop N1";

            Segment(x => x.PartyIdentification, 0);
            Segment(x => x.AdditionalNameInformation, 1);
            Segment(x => x.IndividualNameStructureComponents, 2);
            Segment(x => x.PartyLocation, 3);
            Segment(x => x.GeographicLocation, 4);
        }
    }
}