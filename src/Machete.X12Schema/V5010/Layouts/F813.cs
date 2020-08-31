namespace Machete.X12Schema.V5010
{
    using X12;


    public interface F813 :
        X12Layout
    {
        Segment<ISA> InterchangeControlHeader { get; }

        LayoutList<F813> Transaction { get; }

        Segment<IEA> InterchangeControlTrailer { get; } 
    }
}