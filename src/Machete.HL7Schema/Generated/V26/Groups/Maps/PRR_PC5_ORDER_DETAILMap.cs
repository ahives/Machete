// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// PRR_PC5_ORDER_DETAIL (GroupMap) - 
    /// </summary>
    public class PRR_PC5_ORDER_DETAILMap :
        HL7LayoutMap<PRR_PC5_ORDER_DETAIL>
    {
        public PRR_PC5_ORDER_DETAILMap()
        {
            Segment(x => x.OBR, 0, x => x.Required = true);
            Segment(x => x.Hxx, 1, x => x.Required = true);
            Segment(x => x.NTE, 2);
            Segment(x => x.VAR, 3);
            Layout(x => x.OrderObservation, 4);
        }
    }
}