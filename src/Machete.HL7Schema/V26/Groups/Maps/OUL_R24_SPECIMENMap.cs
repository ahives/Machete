// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// OUL_R24_SPECIMEN (GroupMap) - 
    /// </summary>
    public class OUL_R24_SPECIMENMap :
        HL7V26LayoutMap<OUL_R24_SPECIMEN>
    {
        public OUL_R24_SPECIMENMap()
        {
            Segment(x => x.SPM, 0, x => x.Required = true);
            Segment(x => x.OBX, 1);
            Layout(x => x.Container, 2);
        }
    }
}