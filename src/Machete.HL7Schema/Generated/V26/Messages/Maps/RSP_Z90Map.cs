// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// RSP_Z90 (MessageMap) - 
    /// </summary>
    public class RSP_Z90Map :
        HL7LayoutMap<RSP_Z90>
    {
        public RSP_Z90Map()
        {
            Segment(x => x.MSH, 0, x => x.Required = true);
            Segment(x => x.SFT, 1);
            Segment(x => x.UAC, 2);
            Segment(x => x.MSA, 3, x => x.Required = true);
            Segment(x => x.ERR, 4);
            Segment(x => x.QAK, 5, x => x.Required = true);
            Segment(x => x.QPD, 6, x => x.Required = true);
            Segment(x => x.RCP, 7, x => x.Required = true);
            Layout(x => x.QueryResponse, 8, x => x.Required = true);
            Segment(x => x.DSC, 9, x => x.Required = true);
        }
    }
}