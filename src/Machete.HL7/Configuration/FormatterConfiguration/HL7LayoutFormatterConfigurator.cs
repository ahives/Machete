namespace Machete.HL7.FormatterConfiguration
{
    using Formatters;
    using Machete.FormatterConfiguration;


    public class HL7LayoutFormatterConfigurator<TSchema, TLayout> :
        FormatterConfigurator<TSchema>,
        IHL7FormatterConfigurator<TSchema>
        where TSchema : HL7Entity
        where TLayout : HL7Layout
    {
        public HL7LayoutFormatterConfigurator(ISchema<TSchema> schema)
            : base(schema)
        {
        }

        public IFormatter<TSchema, TLayout> Build()
        {
            return new HL7LayoutFormatter<TSchema, TLayout>(Schema);
        }
    }
}