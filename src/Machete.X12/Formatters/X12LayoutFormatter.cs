namespace Machete.X12.Formatters
{
    using System.IO;
    using System.Threading.Tasks;


    public class X12LayoutFormatter<TSchema, TLayout> :
        IFormatter<TSchema, TLayout>
        where TSchema : X12Entity
        where TLayout : X12Layout
    {
        readonly ISchema<TSchema> _schema;
        readonly X12FormatterSettings _settings;

        public X12LayoutFormatter(ISchema<TSchema> schema)
        {
            _schema = schema;

            _settings = new X12FormatterSettings();
        }

        public async Task<FormatResult<TSchema>> FormatAsync(Stream output, LayoutList<TLayout> input)
        {
            throw new System.NotImplementedException();
        }
    }
}