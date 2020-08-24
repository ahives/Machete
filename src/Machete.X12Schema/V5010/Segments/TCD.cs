namespace Machete.X12Schema.V5010
{
    using System;
    using X12;


    public interface TCD :
        X12Segment
    {
        Value<string> AssignedIdentification { get; }

        Value<DateTime> Date { get; }

        Value<TimeSpan> Time { get; }

        Value<string> LocationQualifier04 { get; }

        Value<string> LocationIdentifier05 { get; }

        Value<string> StateOrProvinceCode06 { get; }

        Value<string> LocationQualifier07 { get; }

        Value<string> LocationIdentifier08 { get; }

        Value<string> StateOrProvinceCode09 { get; }

        Value<decimal> MeasurementValue10 { get; }

        Value<decimal> MeasurementValue11 { get; }

        Value<decimal> MonetaryAmount12 { get; }

        Value<decimal> MonetaryAmount13 { get; }

        Value<decimal> MonetaryAmount14 { get; }

        Value<decimal> MonetaryAmount15 { get; }

        Value<string> RelationshipCode { get; }
    }
}