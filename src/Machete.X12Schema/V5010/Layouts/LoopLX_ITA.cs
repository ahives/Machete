namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopLX_ITA :
        X12Layout
    {
        Segment<ITA> AllowanceChargeOrService { get; }
        
        Segment<DTM> DateOrTimeReference { get; }
    }
}