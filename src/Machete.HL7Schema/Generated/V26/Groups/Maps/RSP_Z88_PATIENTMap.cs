// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// RSP_Z88_PATIENT (GroupMap) - 
    /// </summary>
    public class RSP_Z88_PATIENTMap :
        HL7LayoutMap<RSP_Z88_PATIENT>
    {
        public RSP_Z88_PATIENTMap()
        {
            Segment(x => x.PID, 0, x => x.Required = true);
            Segment(x => x.PD1, 1);
            Segment(x => x.NTE, 2);
            Layout(x => x.Allergy, 3);
        }
    }
}