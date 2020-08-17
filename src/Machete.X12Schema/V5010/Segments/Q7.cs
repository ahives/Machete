namespace Machete.X12Schema.V5010
{
    using X12;


    public interface Q7 :
        X12Segment
    {
        Value<string> LadingExceptionCode { get; }
        Value<string> PackagingFormCode { get; }
        Value<int> LadingQuantity { get; }
    }
}