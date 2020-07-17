namespace Machete.X12.Tests.Layouts
{
    using NUnit.Framework;
    using Testing;
    using X12Schema.V5010;


    [TestFixture]
    public class MissingLayoutListTests :
        X12MacheteTestHarness<X12v5010, X12Entity>
    {
        [Test(Description = "Condition : PatientControlNumber => EJ, InstitutionalTypeOfBill => BLT, MedicalRecordIdentificationNumber => EA, ClaimIdentificationNumber => D9")]
        public void Test1()
        {
            string message =
                @"ISA*00*          *00*          *ZZ*EMEDNYBAT      *ZZ*00DJ           *180625*0712*^*00501*176073292*0*P*:
GS*HP*EMEDNYBAT*00DJ*20180625*07121200*176073292*X*005010X221A1
ST*277*0001*005010X228
BHT*0085*08*277PEND123*20070210*1635*NO
HL*1**20*1
NM1*PR*2*ABC INSURANCE*****PI*12345
HL*2*1*21*1
NM1*41*2*XYZ SERVICE*****46*X67E
HL*3*2*19*1
NM1*1P*2*HOME HOSPITAL*****XX*1666666661
SE*35*0001
GE*1*1
IEA*1*176073292";

            var parseResult = Parser.Parse(message);

            Assert.IsTrue(Schema.TryGetLayout(out ILayoutParserFactory<HISN277, X12Entity> layout));

            var query = parseResult.CreateQuery(layout);

            var queryResult = parseResult.Query(query);

            Assert.IsTrue(queryResult.HasResult);

            var transactions = queryResult.Select(x => x.Transactions)[0];
            
            Assert.IsTrue(transactions.HasValue);
            Assert.IsFalse(transactions.Select(x => x.PatientDetail)[0].HasValue);
            Assert.IsNull(transactions.Select(x => x.PatientDetail)[0].Value);
        }
        
        [Test(Description = "Condition : PatientControlNumber => EJ, InstitutionalTypeOfBill => BLT, MedicalRecordIdentificationNumber => EA, ClaimIdentificationNumber => D9"), Explicit]
        public void Test2()
        {
            string message =
                @"ISA*00*          *00*          *ZZ*EMEDNYBAT      *ZZ*00DJ           *180625*0712*^*00501*176073292*0*P*:
GS*HP*EMEDNYBAT*00DJ*20180625*07121200*176073292*X*005010X221A1
ST*277*0001*005010X228
BHT*0085*08*277PEND123*20070210*1635*NO
HL*1**20*1
NM1*PR*2*ABC INSURANCE*****PI*12345
HL*2*1*21*1
NM1*41*2*XYZ SERVICE*****46*X67E
HL*3*2*19*1
NM1*1P*2*HOME HOSPITAL*****XX*1666666661
SE*35*0001
GE*1*1
IEA*1*176073292";

            var parseResult = Parser.Parse(message);

            Assert.IsTrue(Schema.TryGetLayout(out ILayoutParserFactory<HISN277, X12Entity> layout));

            var query = parseResult.CreateQuery(layout);

            var queryResult = parseResult.Query(query);

            Assert.IsTrue(queryResult.HasResult);

            var transactions = queryResult.Select(x => x.Transactions)[0];
            
            Assert.IsTrue(transactions.HasValue);

            Assert.IsFalse(transactions.Select(x => x.PatientDetail).TryGetValue(0, out var layout1));

            var layout1Value = layout1.Value.ServiceProviderLevel.Value;
            
//            Assert.Throws<LayoutMissingException>(() =>
//            {
//                var patientControlNumber = transactions
//                    .Select(x => x.PatientDetail)[0];
//            });
        }
        
        [Test(Description = @"Condition : PatientControlNumber => EJ,
            InstitutionalTypeOfBill => BLT,
            MedicalRecordIdentificationNumber => EA,
            ClaimIdentificationNumber => D9"), Explicit]
        public void Test3()
        {
            string message =
                @"ISA*00*          *00*          *ZZ*EMEDNYBAT      *ZZ*00DJ           *180625*0712*^*00501*176073292*0*P*:
GS*HP*EMEDNYBAT*00DJ*20180625*07121200*176073292*X*005010X221A1
ST*277*0001*005010X228
BHT*0085*08*277PEND123*20070210*1635*NO
HL*1**20*1
NM1*PR*2*ABC INSURANCE*****PI*12345
SE*35*0001
GE*1*1
IEA*1*176073292";

            var parseResult = Parser.Parse(message);

            Assert.IsTrue(Schema.TryGetLayout(out ILayoutParserFactory<HISN277, X12Entity> layout));

            var query = parseResult.CreateQuery(layout);

            var queryResult = parseResult.Query(query);

            Assert.IsTrue(queryResult.HasResult);

            var transactions = queryResult.Select(x => x.Transactions)[0];
            
            Assert.IsTrue(transactions.HasValue);

//            Assert.IsFalse(transactions.Select(x => x.PatientDetail).TryGetValue(0, out var layout1));

//            var layout1Value1 = layout1.Value;
//            var layout1Value = layout1.Select(x => x.ServiceProviderLevel).Value;
            
            Assert.Throws<LayoutMissingException>(() =>
            {
                var payerName = transactions
                    .Select(x => x.InformationSourceDetail)
                    .TryGetValue(-1, out var layout1);

                var layout1Value = layout1.Value;
//                    .Value;
//                    .Select(x => x.PayerName)
//                    .Value;
//                var patientControlNumber = transactions
//                    .Select(x => x.PatientDetail)[0];
            });
        }
        
        [Test]
        public void Test()
        {
            
        }
    }
}