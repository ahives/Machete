// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26
{
    using HL7;

    /// <summary>
    /// ADT_A03_PROCEDURE (Group) - 
    /// </summary>
    public interface ADT_A03_PROCEDURE :
        HL7Layout
    {
        /// <summary>
        /// PR1
        /// </summary>
        Segment<PR1> PR1 { get; }

        /// <summary>
        /// ROL
        /// </summary>
        SegmentList<ROL> ROL { get; }
    }
}