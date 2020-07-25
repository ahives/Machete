namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopLIN_846 : X12Layout
    {
        Segment<LIN> ItemIdentification { get; }
    }
}