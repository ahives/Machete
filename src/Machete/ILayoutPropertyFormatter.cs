namespace Machete
{
    public interface ILayoutPropertyFormatter<TLayout>
        where TLayout : Layout
    {
        void Format(FormatLayoutContext<TLayout> context);
    }


    public interface FormatLayoutContext<out TLayout> :
        FormatContext
        where TLayout : Layout
    {
        TLayout Layout { get; }
    }
}