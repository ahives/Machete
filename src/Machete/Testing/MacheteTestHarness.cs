namespace Machete.Testing
{
    using System;


    public abstract class MacheteTestHarness<TSchema, TLayout> :
        IMacheteTestHarness<TSchema>
        where TSchema : Entity
        where TLayout : Layout
    {
        readonly Lazy<ISchema<TSchema>> _schema;
        readonly Lazy<IParser<TSchema>> _parser;
        readonly Lazy<IFormatter<TSchema>> _formatter;
        readonly Lazy<IFormatter<TSchema, TLayout>> _layoutFormatter;

        public MacheteTestHarness()
        {
            _schema = new Lazy<ISchema<TSchema>>(CreateSchema);
            _parser = new Lazy<IParser<TSchema>>(() => CreateParser(Schema));
            _formatter = new Lazy<IFormatter<TSchema>>(() => CreateFormatter(Schema));
            _layoutFormatter = new Lazy<IFormatter<TSchema, TLayout>>(() => CreateLayoutFormatter(Schema));
        }

        public ISchema<TSchema> Schema => _schema.Value;
        public IParser<TSchema> Parser => _parser.Value;
        public IFormatter<TSchema> Formatter => _formatter.Value;
        public IFormatter<TSchema, TLayout> LayoutFormatter => _layoutFormatter.Value;

        protected abstract ISchema<TSchema> CreateSchema();
        protected abstract IParser<TSchema> CreateParser(ISchema<TSchema> schema);
        protected abstract IFormatter<TSchema> CreateFormatter(ISchema<TSchema> schema);
        protected abstract IFormatter<TSchema, TLayout> CreateLayoutFormatter(ISchema<TSchema> schema);
    }
}