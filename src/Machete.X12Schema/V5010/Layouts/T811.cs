namespace Machete.X12Schema.V5010
{
    using X12;


    public interface T811 :
        X12Layout
    {
        Segment<GS> FunctionalGroupHeader { get; }

        Segment<ST> TransactionSetHeader { get; }

        Segment<BIG> BeginningSegmentForInvoice { get; }

        Segment<NTE> SpecialInstructions { get; }

        Segment<CUR> Currency { get; }

        SegmentList<REF> ReferenceInformation { get; }

        Segment<PER> AdministrativeCommunicationsContact { get; }

        Segment<ITD> TermsOfSale { get; }

        Segment<DTM> DateOrTimeReference { get; }

        SegmentList<TXI> TaxInformation { get; }

        LayoutList<LoopN1_1_811> LoopN1 { get; }

        LayoutList<LoopFA1_811> LoopFA1 { get; }

        LayoutList<LoopHL_811> LoopHL { get; }

        Segment<TDS> TotalMonetaryValueSummary { get; }

        LayoutList<LoopITA_811> LoopITA { get; }

        LayoutList<LoopBAL_811> LoopBAL { get; }

        LayoutList<LoopN1_2_811> LoopN1_2 { get; }

        Segment<CTT> TransactionTotals { get; }

        Segment<SE> TransactionSetTrailer { get; }

        Segment<GE> FunctionalGroupTrailer { get; }
    }
}