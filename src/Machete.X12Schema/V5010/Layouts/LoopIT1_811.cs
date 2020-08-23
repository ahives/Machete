namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopIT1_811 :
        X12Layout
    {
        Segment<IT1> BaseLineItemData { get; }

        SegmentList<SI> ServiceCharacteristicInformation { get; }

        SegmentList<PID> ProductItemDescription { get; }

        SegmentList<MEA> Measurements { get; }

        Segment<INC> InstallmentInformation { get; }

        SegmentList<TXI> TaxInformation { get; }

        SegmentList<REF> ReferenceInformation { get; }

        SegmentList<DTM> DateTimeReference { get; }

        SegmentList<MSG> MessageText { get; }

        Segment<CAD> CarrierDetails { get; }

        SegmentList<YNQ> YesNoQuestion { get; }

        SegmentList<LQ> IndustryCodeIdentification { get; }

        SegmentList<LCD> PlaceLocationDescription { get; }

        LayoutList<HL_IT1_AMT_811> AMTLoop { get; }

        LayoutList<HL_IT1_QTY_811> QTYLoop { get; }

        LayoutList<HL_IT1_ITA_811> ITALoop { get; }

        LayoutList<HL_IT1_NM1_811> NM1Loop { get; }
    }
}