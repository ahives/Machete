namespace Machete.X12Schema.V5010
{
    using System;
    using X12;


    public interface LCD :
        X12Segment
    {
        Value<string> AssignedIdentification { get; }

        Value<string> EntityIdentifierCode { get; }

        Value<string> ActionCode { get; }

        Value<DateTime> Date { get; }

        Value<string> IdentifierCodeQualifier { get; }

        Value<string> IdentifierCode { get; }
    }
}