namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopPID_855 :
        X12Layout
    {
        Segment<PID> ProductOrITemDescription { get; }
        
        SegmentList<MEA> Measurements { get; }
    }
}