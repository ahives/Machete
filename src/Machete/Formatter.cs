namespace Machete
{
    public static class Formatter
    {
        /// <summary>
        /// The factory base for all formatters to make it easy to discover available formatter types.
        /// </summary>
        public static readonly IFormatterFactorySelector Factory = new UnusedFormatterFactorySelector();


        class UnusedFormatterFactorySelector :
            IFormatterFactorySelector
        {
        }
    }
}