namespace Machete.X12.Tests.Layouts
{
    using System;
    using NUnit.Framework;
    using Testing;
    using X12Schema.V5010;


    [TestFixture]
    public class Parsing850TransactionSetTests :
        X12MacheteTestHarness<X12v5010, X12Entity>
    {
        [Test]
        public void Test()
        {
            string message =
                @"ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00400*000003438*0*P*>
GS*PO*4405197800*999999999*20101127*1719*1421*X*004010VICS
ST*850*000000010
BEG*00*SA*08292233294**20101127*610385385
REF*DP*038
REF*PS*R
ITD*14*3*2**45**46
DTM*002*20101214
PKG*F*68***PALLETIZE SHIPMENT
PKG*F*66***REGULAR
TD5*A*92*P3**SEE XYZ RETAIL ROUTING GUIDE
N1*ST*XYZ RETAIL*9*0003947268292
N3*31875 SOLON RD
N4*SOLON*OH*44139
PO1*1*120*EA*9.25*TE*CB*065322-117*PR*RO*VN*AB3542
PID*F****SMALL WIDGET
PO4*4*4*EA*PLT94**3*LR*15*CT
PO1*2*220*EA*13.79*TE*CB*066850-116*PR*RO*VN*RD5322
PID*F****MEDIUM WIDGET
PO4*2*2*EA
PO1*3*126*EA*10.99*TE*CB*060733-110*PR*RO*VN*XY5266
PID*F****LARGE WIDGET
PO4*6*1*EA*PLT94**3*LR*12*CT
PO1*4*76*EA*4.35*TE*CB*065308-116*PR*RO*VN*VX2332
PID*F****NANO WIDGET
PO4*4*4*EA*PLT94**6*LR*19*CT
PO1*5*72*EA*7.5*TE*CB*065374-118*PR*RO*VN*RV0524
PID*F****BLUE WIDGET
PO4*4*4*EA
PO1*6*696*EA*9.55*TE*CB*067504-118*PR*RO*VN*DX1875
PID*F****ORANGE WIDGET
PO4*6*6*EA*PLT94**3*LR*10*CT
CTT*6
AMT*1*13045.94
SE*33*000000010
GE*1*1421
IEA*1*000003438";
 
            var parseResult = Parser.Parse(message);

            Assert.IsTrue(Schema.TryGetLayout(out ILayoutParserFactory<SC850, X12Entity> layout));

            var query = parseResult.CreateQuery(layout);

            var queryResult = parseResult.Query(query);

            Assert.IsTrue(queryResult.HasResult);

            var date = queryResult
                .Select(x => x.Transaction)[0]
                .Select(x => x.BeginningPurchaseOrder)
                .Select(x => x.Date)
                .ValueOrDefault();

            var contractNumber = queryResult
                .Select(x => x.Transaction)[0]
                .Select(x => x.BeginningPurchaseOrder)
                .Select(x => x.ContractNumber)
                .ValueOrDefault();
            
            var productDescription = queryResult
                .Select(x => x.Transaction)[0]
                .Select(x => x.LoopPO1)[0]
                .Select(x => x.LoopPID)[0]
                .Select(x => x.ProductOrITemDescription)
                .Select(x => x.Description)
                .ValueOrDefault();

            var quantity = queryResult
                .Select(x => x.Transaction)[0]
                .Select(x => x.LoopPO1)[0]
                .Select(x => x.BaselineItemData)
                .Select(x => x.Quantity)
                .ValueOrDefault();

            Assert.AreEqual(new DateTime(2010, 11, 27), date);
            Assert.AreEqual("610385385", contractNumber);
            Assert.AreEqual("SMALL WIDGET", productDescription);
            Assert.AreEqual(120, quantity);
        }
    }
}