namespace Machete.Layouts.Providers
{
    using System.Reflection;
    using Internals.Reflection;


    public class SegmentLayoutPropertyFormatter<TLayout, TSegment> :
        ILayoutPropertyFormatter<TLayout>
        where TLayout : Layout
        where TSegment : Entity
    {
        readonly ISegmentFormatter<TSegment> _formatter;
        ReadOnlyProperty<TLayout, Entity<TSegment>> _property;

        public SegmentLayoutPropertyFormatter(PropertyInfo propertyInfo, ISegmentFormatter<TSegment> formatter)
        {
            _formatter = formatter;
            _property = new ReadOnlyProperty<TLayout, Entity<TSegment>>(propertyInfo);
        }

        public void Format(FormatLayoutContext<TLayout> context)
        {
            throw new System.NotImplementedException();
        }
    }
}