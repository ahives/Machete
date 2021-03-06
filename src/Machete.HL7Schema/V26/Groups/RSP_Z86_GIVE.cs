// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26
{
    using HL7;

    /// <summary>
    /// RSP_Z86_GIVE (Group) - 
    /// </summary>
    public interface RSP_Z86_GIVE :
        HL7V26Layout
    {
        /// <summary>
        /// RXG
        /// </summary>
        Segment<RXG> RXG { get; }

        /// <summary>
        /// RXR
        /// </summary>
        SegmentList<RXR> RXR { get; }

        /// <summary>
        /// RXC
        /// </summary>
        SegmentList<RXC> RXC { get; }
    }
}