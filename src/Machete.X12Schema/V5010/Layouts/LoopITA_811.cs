namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopITA_811 :
        X12Layout
    {

        Segment<ITA> AllowanceChargeOrService { get; }

        Segment<DTM> DateTimeReference { get; }

        Segment<AMT> MonitaryAmountInformation { get; }

        Segment<SI> ServiceCharacteristicIdentification { get; }

        Segment<REF> ReferenceInformation { get; }

        Segment<CUR> Currency { get; }
    }
}