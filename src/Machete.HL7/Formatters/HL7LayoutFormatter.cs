namespace Machete.HL7.Formatters
{
    using System.IO;
    using System.Threading.Tasks;
    using Internals.Extensions;
    using Machete.Formatters;


    public class HL7LayoutFormatter<TSchema, TLayout> :
        IFormatter<TSchema, TLayout>
        where TSchema : HL7Entity
        where TLayout : HL7Layout
    {
        readonly ISchema<TSchema> _schema;
        readonly HL7FormatterSettings _settings;

        public HL7LayoutFormatter(ISchema<TSchema> schema)
        {
            _schema = schema;

            _settings = new HL7FormatterSettings();
        }

        public async Task<FormatResult<TSchema>> FormatAsync(Stream output, LayoutList<TLayout> input)
        {
            using (var writer = new StreamWriter(output))
            {
                for (int i = 0;; i++)
                {
                    Layout<TLayout> entity;
                    if (!input.TryGetValue(i, out entity))
                        break;

                    HL7Layout layout = entity as HL7Layout;
                    if (layout == null)
                        throw new MacheteSchemaException($"The entity is not an HL7 template: {TypeCache.GetShortName(entity.GetType())}");
                    
                    ILayoutFormatter formatter;
                    if (_schema.TryGetLayoutFormatter(layout, out formatter))
                    {
                        var context = new StringBuilderFormatContext();
                        context.AddSettings(_settings);
                        
                        formatter.Format(context, layout);

                        await writer.WriteAsync(context.ToString()).ConfigureAwait(false);
                    }
                    else
                    {
                        throw new MacheteSchemaException($"The entity type was not found: {TypeCache.GetShortName(layout.GetType())}");
                    }
                }
            }

            return new HL7FormatResult<TSchema>();
        }
    }
}