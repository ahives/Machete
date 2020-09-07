namespace Machete.X12Schema.V5010
{
    using System;
    using X12;


    public interface RIC :
        X12Segment
    {
        Value<string> PaymentMethodCode { get; }
        Value<string> CodeListQualifierCode { get; }
        Value<string> IndustryCode { get; }
        Value<string> MonetaryAmount { get; }
        Value<string> CreditDebitFlagCode { get; }
        Value<string> AccountNumber1 { get; }
        Value<string> AccountNumberQualifier1 { get; }
        Value<string> IdNumberQualifier1 { get; }
        Value<string> IdentifierNumber1 { get; }
        Value<string> AccountNumber2 { get; }
        Value<string> AccountNumberQualifier2 { get; }
        Value<string> IdNumberQualifier2 { get; }
        Value<string> IdentifierNumber2 { get; }
        Value<string> AccountNumber3 { get; }
        Value<string> AccountNumberQualifier3 { get; }
        Value<string> IdNumberQualifier3 { get; }
        Value<string> IdentifierNumber3 { get; }
        Value<DateTime> Date { get; }
    }
}