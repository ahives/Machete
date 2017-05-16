// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// DFT_P11_FINANCIAL_OBSERVATION (GroupMap) - 
    /// </summary>
    public class DFT_P11_FINANCIAL_OBSERVATIONMap :
        HL7LayoutMap<DFT_P11_FINANCIAL_OBSERVATION>
    {
        public DFT_P11_FINANCIAL_OBSERVATIONMap()
        {
            Segment(x => x.OBX, 0, x => x.Required = true);
            Segment(x => x.NTE, 1);
        }
    }
}