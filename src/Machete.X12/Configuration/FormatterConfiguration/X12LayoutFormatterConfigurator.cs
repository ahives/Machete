namespace Machete.X12.Configuration.FormatterConfiguration
{
    using Formatters;
    using Machete.FormatterConfiguration;


    public class X12LayoutFormatterConfigurator<TSchema, TLayout> :
        FormatterConfigurator<TSchema>,
        IX12FormatterConfigurator<TSchema>
        where TSchema : X12Entity
        where TLayout : X12Layout
    {
        public X12LayoutFormatterConfigurator(ISchema<TSchema> schema)
            : base(schema)
        {
        }

        public IFormatter<TSchema, TLayout> Build()
        {
            return new X12LayoutFormatter<TSchema, TLayout>(Schema);
        }
    }
}