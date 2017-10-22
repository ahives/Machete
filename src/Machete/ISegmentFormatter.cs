namespace Machete
{
    public interface ISegmentFormatter<TSegment>
        where TSegment : Entity
    {
        void Format(FormatSegmentContext<TSegment> context);
    }


    public interface FormatSegmentContext<out TSegment> :
        FormatContext
        where TSegment : Entity
    {
        Entity<TSegment> Segment { get; }
    }
}