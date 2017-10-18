namespace Machete
{
    public interface ILayoutPropertyFormatter<in TLayout>
    where TLayout : Layout
    {
        void Format(LayoutFormatContext<TLayout> context);
    }


    public interface LayoutFormatContext<out TLayout> :
        FormatContext
    where TLayout : Layout
    {
        TLayout Layout { get; }
    }
}