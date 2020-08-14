namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopLX_2_811 :
        X12Layout
    {
        Segment<LX> TransactionSetLineNumber { get; }

        Segment<REF> ReferenceInformation { get; }

        LayoutList<LoopLX_AMT> LoopLX_AMT { get; }

        LayoutList<LoopLX_ITA> LoopLX_ITA { get; }
    }
}