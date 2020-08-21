namespace Machete.X12Schema.V5010
{
    using System;
    using X12;


    public interface B10 :
        X12Segment
    {
        Value<string> ReferenceIdentification1 { get; }

        Value<string> ShipmentIdentificationNumber { get; }

        Value<string> StandardCarrierAlphaCode { get; }

        Value<string> InquiryRequestNumber { get; }

        Value<string> ReferenceIdentificationQualifier { get; }

        Value<string> ReferenceIdentification2 { get; }

        Value<string> YesNoConditionOrResponseCode { get; }

        Value<DateTime> Date { get; }

        Value<TimeSpan> Time { get; }
    }
}