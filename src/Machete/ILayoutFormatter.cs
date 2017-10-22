namespace Machete
{
    using System;


    public interface ILayoutFormatter<TLayout> :
        ILayoutFormatter
        where TLayout : Layout
    {
        /// <summary>
        /// Format a layout.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="layout"></param>
        void Format(FormatContext context, TLayout layout);

        /// <summary>
        /// Format a list of layouts.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="layouts"></param>
        void Format(FormatContext context, LayoutList<TLayout> layouts);
    }


    public interface ILayoutFormatter
    {
        Type LayoutType { get; }

        void Format<T>(FormatContext context, T layout)
            where T : Layout;
    }
}