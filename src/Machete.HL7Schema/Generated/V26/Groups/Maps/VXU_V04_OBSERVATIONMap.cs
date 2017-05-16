// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// VXU_V04_OBSERVATION (GroupMap) - 
    /// </summary>
    public class VXU_V04_OBSERVATIONMap :
        HL7LayoutMap<VXU_V04_OBSERVATION>
    {
        public VXU_V04_OBSERVATIONMap()
        {
            Segment(x => x.OBX, 0, x => x.Required = true);
            Segment(x => x.NTE, 1);
        }
    }
}