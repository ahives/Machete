namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopMN_846 : X12Layout
    {
        Segment<MAN> MarksAndNumberInformation { get; }
        Segment<MEA> Measurements { get; }
    }
}