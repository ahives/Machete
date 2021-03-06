// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// ADT_A18 (MessageMap) - 
    /// </summary>
    public class ADT_A18Map :
        HL7V26LayoutMap<ADT_A18>
    {
        public ADT_A18Map()
        {
            Segment(x => x.MSH, 0, x => x.Required = true);
            Segment(x => x.SFT, 1);
            Segment(x => x.EVN, 2, x => x.Required = true);
            Segment(x => x.PID, 3, x => x.Required = true);
            Segment(x => x.PD1, 4);
            Segment(x => x.MRG, 5, x => x.Required = true);
            Segment(x => x.PV1, 6, x => x.Required = true);
        }
    }
}