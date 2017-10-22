namespace Machete.HL7.Testing
{
    using System.Linq;
    using Machete.Testing;


    public class HL7MacheteTestHarness<TVersion, TSchema, TLayout> :
        IMacheteTestHarness<TSchema>
        where TSchema : HL7Entity
        where TVersion : TSchema
        where TLayout : HL7Layout
    {
        static readonly MacheteTestHarness<TSchema, TLayout> _harness = new Harness();

        public ISchema<TSchema> Schema => _harness.Schema;
        public IParser<TSchema> Parser => _harness.Parser;
        public IFormatter<TSchema> Formatter => _harness.Formatter;
        public IFormatter<TSchema, TLayout> LayoutFormatter => _harness.LayoutFormatter;

        public string CleanupText(string text)
        {
            string cleaned = text
                .Replace("\r\n", "\r")
                .Replace("\n", "\r")
                .Replace("\r\r", "\r")
                .Trim('\r', '\n');

            string trimmed = string.Join("\r",
                cleaned.Split('\r').Select(line => line.TrimEnd('|')).ToArray());

            return trimmed;
        }


        class Harness :
            MacheteTestHarness<TSchema, TLayout>
        {
            protected override ISchema<TSchema> CreateSchema()
            {
                return Machete.Schema.Factory.CreateHL7<TSchema>(cfg => cfg.AddFromNamespaceContaining<TVersion>());
            }

            protected override IParser<TSchema> CreateParser(ISchema<TSchema> schema)
            {
                return Machete.Parser.Factory.CreateHL7(schema);
            }

            protected override IFormatter<TSchema> CreateFormatter(ISchema<TSchema> schema)
            {
                return Machete.Formatter.Factory.CreateHL7(schema);
            }

            protected override IFormatter<TSchema, TLayout> CreateLayoutFormatter(ISchema<TSchema> schema)
            {
                return Machete.Formatter.Factory.CreateHL7<TSchema, TLayout>(schema);
            }
        }
    }
}