namespace Machete.X12Schema.V5010
{
    using X12;


    public interface F827 :
        X12Layout
    {
        Segment<ISA> InterchangeControlHeader { get; }

        LayoutList<T827> Transaction { get; }

        Segment<IEA> InterchangeControlTrailer { get; }
    }
}