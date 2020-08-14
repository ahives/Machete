namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopQTY_811 :
        X12Layout
    {
        Segment<QTY> Quantity { get; }
        
        Segment<SI> ServiceCharacteristicIdentification { get; }
    }
}