// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26
{
    using HL7;

    /// <summary>
    /// QSB_Q16 (Message) - 
    /// </summary>
    public interface QSB_Q16 :
        HL7Layout
    {
        /// <summary>
        /// MSH
        /// </summary>
        Segment<MSH> MSH { get; }

        /// <summary>
        /// SFT
        /// </summary>
        SegmentList<SFT> SFT { get; }

        /// <summary>
        /// UAC
        /// </summary>
        Segment<UAC> UAC { get; }

        /// <summary>
        /// QPD
        /// </summary>
        Segment<QPD> QPD { get; }

        /// <summary>
        /// RCP
        /// </summary>
        Segment<RCP> RCP { get; }

        /// <summary>
        /// DSC
        /// </summary>
        Segment<DSC> DSC { get; }
    }
}