// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// ORN_O08_TIMING (GroupMap) - 
    /// </summary>
    public class ORN_O08_TIMINGMap :
        HL7LayoutMap<ORN_O08_TIMING>
    {
        public ORN_O08_TIMINGMap()
        {
            Segment(x => x.TQ1, 0, x => x.Required = true);
            Segment(x => x.TQ2, 1);
        }
    }
}