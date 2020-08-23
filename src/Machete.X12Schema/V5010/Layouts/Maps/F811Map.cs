namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class F811Map :
        X12LayoutMap<F811, X12Entity>
    {
        public F811Map()
        {
            Id = "F811";
            Name = "811 - Consolidated Service Invoice/Statement";
            
            Segment(x => x.InterchangeControlHeader, 0);
            Layout(x => x.Transaction, 1);
            Segment(x => x.InterchangeControlTrailer, 2);
        }
    }
}