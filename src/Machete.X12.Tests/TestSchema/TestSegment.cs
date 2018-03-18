namespace Machete.X12.Tests.TestSchema
{
    public interface TestSegment :
        X12Segment
    {
        Value<string> Field1 { get; }
        
        ValueList<string> Field2 { get; }
    }
}