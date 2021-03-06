namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopN9_2_865Map :
        X12LayoutMap<LoopN9_2_865, X12Entity>
    {
        public LoopN9_2_865Map()
        {
            Id = "Loop_N9_2_865";
            Name = "Loop N9";
            
            Segment(x => x.ExtendedReferenceInformation, 0);
            Segment(x => x.DateOrTimeReference, 1);
            Segment(x => x.Text, 2);
        }
    }
}