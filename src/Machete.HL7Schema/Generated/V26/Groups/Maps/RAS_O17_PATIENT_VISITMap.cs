// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// RAS_O17_PATIENT_VISIT (GroupMap) - 
    /// </summary>
    public class RAS_O17_PATIENT_VISITMap :
        HL7LayoutMap<RAS_O17_PATIENT_VISIT>
    {
        public RAS_O17_PATIENT_VISITMap()
        {
            Segment(x => x.PV1, 0, x => x.Required = true);
            Segment(x => x.PV2, 1);
        }
    }
}