namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopSLN_846 : 
        X12Layout
    {
        Segment<SLN> SublineItemDetail { get; }
        
        Segment<PID> ItemDescription { get; }
        
        Segment<MEA> Measurements { get; }
        
        Segment<PKG> MarkingPackagingLoading { get; }
        
        LayoutList<LoopMN_846> LoopMAN_846 { get; }
    }
}