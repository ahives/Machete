namespace Machete.X12Schema.V5010
{
    using X12;


    public interface TC2 :
        X12Segment
    {
        Value<string> CommodityCodeQualifier { get; }
        
        Value<string> CommodityCode { get; }
    }
}