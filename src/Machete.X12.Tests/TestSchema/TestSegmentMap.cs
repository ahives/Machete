namespace Machete.X12.Tests.TestSchema
{
    using Configuration;


    public class TestSegmentMap :
        X12SegmentMap<TestSegment, X12Entity>
    {
        public TestSegmentMap()
        {
            Id = "MTS";
            Name = "Test";
            
            Value(x => x.Field1, 1);
            Value(x => x.Field2, 2);
        }
    }
}