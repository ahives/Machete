// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26
{
    using HL7;

    /// <summary>
    /// ORP_O10_PATIENT (Group) - 
    /// </summary>
    public interface ORP_O10_PATIENT :
        HL7Layout
    {
        /// <summary>
        /// PID
        /// </summary>
        Segment<PID> PID { get; }

        /// <summary>
        /// NTE
        /// </summary>
        SegmentList<NTE> NTE { get; }
    }
}