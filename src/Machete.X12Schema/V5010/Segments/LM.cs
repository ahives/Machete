namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LM :
        X12Segment
    {
        Value<string> AgencyQualifierCode { get; }

        Value<string> SourceSubQualifier { get; }
    }
}