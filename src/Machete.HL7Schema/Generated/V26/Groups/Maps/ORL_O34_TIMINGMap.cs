// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// ORL_O34_TIMING (GroupMap) - 
    /// </summary>
    public class ORL_O34_TIMINGMap :
        HL7LayoutMap<ORL_O34_TIMING>
    {
        public ORL_O34_TIMINGMap()
        {
            Segment(x => x.TQ1, 0, x => x.Required = true);
            Segment(x => x.TQ2, 1);
        }
    }
}