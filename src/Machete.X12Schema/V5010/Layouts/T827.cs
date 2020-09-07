namespace Machete.X12Schema.V5010
{
    using X12;


    public interface T827 :
        X12Layout
    {
        Segment<GS> FunctionalGroupHeader { get; }

        Segment<ST> TransactionSetHeader { get; }

        Segment<RIC> FinancialReturn { get; }

        Segment<CUR> Currency { get; }

        SegmentList<TRN> Trace { get; }

        SegmentList<REF> ReferenceInformation { get; }

        SegmentList<DTM> DateOrTimeReference { get; }

        LayoutList<LoopNM1_827> LoopNM1 { get; }

        Segment<SE> TransactionSetTrailer { get; }

        Segment<GE> FunctionalGroupTrailer { get; }
    }
}