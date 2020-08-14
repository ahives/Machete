namespace Machete.X12Schema.V5010
{
    using X12;


    public interface F811 :
        X12Layout
    {
        Segment<ISA> InterchangeControlHeader { get; }
        
        LayoutList<T811> Transaction { get; }
        
        Segment<IEA> InterchangeControlTrailer { get; }
    }
}