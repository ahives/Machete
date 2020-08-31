namespace Machete.X12Schema.V5010
{
    using X12;


    public interface T813 :
        X12Layout
    {
        Segment<GS> FunctionalGroupHeader { get; }

        Segment<ST> TransactionSetHeader { get; }

        Segment<BTI> BeginningTaxInformation { get; }

        SegmentList<DTM> DateTimeReference { get; }

        SegmentList<TIA> TaxInformationAndAmount { get; }

        SegmentList<REF> ReferenceInformation { get; }

        SegmentList<TRN> Trace { get; }

        SegmentList<BPR> BeginningSegmentForPaymentOrderOrRemittanceAdvice { get; }

        LayoutList<LoopN1_1_813> LoopN1 { get; }

        LayoutList<LoopTFS_813> LoopTFS { get; }

        Segment<SE> TransactionSetTrailer { get; }

        Segment<GE> FunctionalGroupTrailer { get; }
    }
}