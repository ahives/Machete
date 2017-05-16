// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// OMG_O19_OBSERVATION (GroupMap) - 
    /// </summary>
    public class OMG_O19_OBSERVATIONMap :
        HL7LayoutMap<OMG_O19_OBSERVATION>
    {
        public OMG_O19_OBSERVATIONMap()
        {
            Segment(x => x.OBX, 0, x => x.Required = true);
            Segment(x => x.NTE, 1);
        }
    }
}