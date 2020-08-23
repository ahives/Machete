namespace Machete.X12Schema.V5010
{
    using X12;

    public interface VEH :
        X12Segment
    {
        Value<int> NumberAssigned { get; }

        Value<string> VehicleIdentificationNumber { get; }

        Value<int> Year { get; }

        Value<string> AgencyQualifierCode { get; }

        Value<string> ReferenceIdentification05 { get; }

        Value<string> ReferenceIdentification06 { get; }

        Value<string> ReferenceIdentification07 { get; }

        Value<decimal> Length { get; }

        Value<string> ReferenceIdentification09 { get; }

        Value<string> StateOrProvinceCode { get; }

        Value<string> LocationIdentifier { get; }

        Value<string> YesNoCondition { get; }

        Value<decimal> Amount { get; }

        Value<string> ActionCode { get; }

        Value<string> YesNoCondition12 { get; }

        Value<decimal> Amount13 { get; }

        Value<string> YesNoCondition14 { get; }

        Value<decimal> Amount15 { get; }

        Value<string> ActionCode16 { get; }

        Value<string> CountryCode17 { get; }

        Value<string> Name { get; }

        Value<string> CountryCode19 { get; }
    }
}