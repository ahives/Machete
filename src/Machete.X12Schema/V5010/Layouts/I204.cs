namespace Machete.X12Schema.V5010
{
    using X12;


    public interface I204 :
        X12Layout
    {
        Segment<ISA> InterchangeControlHeader { get; }
        
        LayoutList<T204> Transaction { get; }
        
        Segment<IEA> InterchangeControlTrailer { get; }
    }
}