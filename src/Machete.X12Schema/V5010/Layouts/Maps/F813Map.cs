namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class F813Map :
        X12LayoutMap<F813, X12Entity>
    {
        public F813Map()
        {
            Id = "F813";
            Name = "813 Electronic Filing of Tax Return Data";

            Segment(x => x.InterchangeControlHeader, 0);
            Layout(x => x.Transaction, 1);
            Segment(x => x.InterchangeControlTrailer, 2);
        }
    }
}