// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// OML_O33_SPECIMEN (GroupMap) - 
    /// </summary>
    public class OML_O33_SPECIMENMap :
        HL7LayoutMap<OML_O33_SPECIMEN>
    {
        public OML_O33_SPECIMENMap()
        {
            Segment(x => x.SPM, 0, x => x.Required = true);
            Segment(x => x.OBX, 1);
            Segment(x => x.SAC, 2);
            Layout(x => x.Order, 3, x => x.Required = true);
        }
    }
}