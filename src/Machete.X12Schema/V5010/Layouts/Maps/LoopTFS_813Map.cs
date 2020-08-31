namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopTFS_813Map :
        X12LayoutMap<LoopTFS_813, X12Entity>
    {
        public LoopTFS_813Map()
        {
            Id = "Loop_TFS_813";
            Name = "Loop TFS";

            Segment(x => x.TaxForm, 0);
            Segment(x => x.ReferenceInformation, 1);
            Segment(x => x.DateOrTimeReference, 2);
            Segment(x => x.MessageText, 3);
            Layout(x => x.LoopN1, 4);
            Layout(x => x.LoopTIA, 5);
            Layout(x => x.LoopFGS, 6);
        }
    }
}