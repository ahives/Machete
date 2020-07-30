namespace Machete.X12Schema.V5010
{
    using X12;


    public interface M846 :
        X12Layout
    {
        Segment<ISA> InterchangeControlHeader { get; }
        
        LayoutList<T846> Transactions { get; }
        
        Segment<IEA> InterchangeControlTrailer { get; }
    }
}