namespace Machete.X12.Tests.EntityFieldAccessTests
{
    using NUnit.Framework;
    using Testing;
    using TestSchema;


    [TestFixture]
    public class ValueListTests :
        X12MacheteTestHarness<TestX12Entity, X12Entity>
    {
        [Test]
        public void Should_be_able_to_parse_simple_list()
        {
            const string message =
                @"ISA*03*6327      *01*NFMC01    *ZZ*MACHETE        *ZZ*PERSEPVS       *090601*0406*^*00501*000026531*0*P*:
GS*HB*FL0738*PERSEPVS*20090601*040612*1*X*005010X279
ST*837*987654*005010X223A3
MTS*ABC*X080^Y646^Z005
SE*43*987654
GE*1*1
IEA*1*000026531";

            ParseResult<X12Entity> parsed = Parser.Parse(message);

            var query = parsed.CreateQuery(q =>
                from isa in q.Select<ISASegment>()
                from gs in q.Select<GSSegment>()
                from st in q.Select<STSegment>()
                from mts in q.Select<TestSegment>()
                select mts);

            var result = parsed.Query(query);

            var simpleValue = result.Select(x => x.Field2)[0];

            Assert.IsTrue(result.HasResult);
            Assert.IsNotNull(simpleValue);
            Assert.AreEqual("X080", simpleValue.ValueOrDefault());
        }

    }
}