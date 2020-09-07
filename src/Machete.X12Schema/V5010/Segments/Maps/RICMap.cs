namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;
    using X12.Values.Converters;


    public class RICMap :
        X12SegmentMap<RIC, X12Entity>
    {
        public RICMap()
        {
            Id = "RIC";
            Name = "Financial Return";
            Value(x => x.PaymentMethodCode, 1, x => x.FixedLength(3));
            Value(x => x.CodeListQualifierCode, 2, x => x.MinLength(1).MaxLength(3));
            Value(x => x.IndustryCode, 3, x => x.MinLength(1).MaxLength(30));
            Value(x => x.MonetaryAmount, 4, x => x.MinLength(1).MaxLength(18).IsRequired());
            Value(x => x.CreditDebitFlagCode, 5, x => x.FixedLength(1).IsRequired());
            Value(x => x.AccountNumber1, 6, x => x.MinLength(1).MaxLength(35));
            Value(x => x.AccountNumberQualifier1, 7, x => x.MinLength(1).MaxLength(3));
            Value(x => x.IdNumberQualifier1, 8, x => x.FixedLength(2));
            Value(x => x.IdentifierNumber1, 9, x => x.MinLength(3).MaxLength(12));
            Value(x => x.AccountNumber2, 10, x => x.MinLength(1).MaxLength(35));
            Value(x => x.AccountNumberQualifier2, 11, x => x.MinLength(1).MaxLength(3));
            Value(x => x.IdNumberQualifier2, 12, x => x.FixedLength(2));
            Value(x => x.IdentifierNumber2, 13, x => x.MinLength(3).MaxLength(12));
            Value(x => x.AccountNumber3, 14, x => x.MinLength(1).MaxLength(35));
            Value(x => x.AccountNumberQualifier3, 15, x => x.MinLength(1).MaxLength(3));
            Value(x => x.IdNumberQualifier3, 16, x => x.FixedLength(2));
            Value(x => x.IdentifierNumber3, 17, x => x.MinLength(3).MaxLength(12));
            Value(x => x.Date, 18, x =>
            {
                x.FixedLength(8);
                x.Converter = X12ValueConverters.VariableDate;
            });
        }
    }
}