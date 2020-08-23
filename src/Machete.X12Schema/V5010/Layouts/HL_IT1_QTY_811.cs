namespace Machete.X12Schema.V5010
{
    using X12;


    public interface HL_IT1_QTY_811 :
        X12Layout
    {
        Segment<QTY> QuantityInformation { get; }

        Segment<QTY> ServiceCharacteristicInformation { get; }
    }
}