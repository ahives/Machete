namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopLX_811 :
        X12Layout
    {
        Segment<LX> TransactionSetLineNumber { get; }
        
        Segment<VEH> VehicleInformation { get; }
        
        Segment<SI> ServiceCharacteristicInformation { get; }
        
        Segment<PID> ProductItemDescription { get; }
        
        Segment<MEA> Measurements { get; }
        
        SegmentList<REF> ReferenceInformation { get; }
        
        SegmentList<AMT> MonetaryAmountInformation { get; }
        
        SegmentList<DTM> DateOrTimeReference { get; }
        
        SegmentList<TXI> TaxInformation { get; }
        
        LayoutList<LoopQTY_811> LoopQTY { get; }
    }
}