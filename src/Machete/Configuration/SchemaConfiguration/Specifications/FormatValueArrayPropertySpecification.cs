﻿namespace Machete.SchemaConfiguration.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Configuration;
    using PropertyMappers;
    using Slices.Providers;
    using Values;


    public class FormatValueArrayPropertySpecification<TEntity, TSchema, TValue> :
        PropertySpecification<TEntity, TSchema, TValue>,
        IDateTimeValueConfigurator<TValue>
        where TEntity : TSchema
        where TSchema : Entity
    {
        readonly Func<string, IValueConverter<TValue>> _valueConverterFactory;
        readonly IValueFormatter<TValue> _valueFormatter;

        public FormatValueArrayPropertySpecification(PropertyInfo property, int position, Func<string, IValueConverter<TValue>> valueConverterFactory,
            IValueFormatter<TValue> valueFormatter)
            : base(property, position)
        {
            _valueConverterFactory = valueConverterFactory;
            _valueFormatter = valueFormatter;
        }

        public string Format { get; set; }

        public override void Apply(IEntityMapBuilder<TEntity, TSchema> builder)
        {
            var valueConverter = _valueConverterFactory(Format);

            ValueArrayFactory<TValue> factory = fragment => new EntityValueArray<TValue>(fragment, valueConverter);

            var mapper = new ValueArrayPropertyMapper<TEntity, TValue>(builder.ImplementationType, Property.Name, Position, factory, Single);

            ITextSliceProvider<TEntity> provider = new ValueArraySliceProvider<TEntity, TValue>(Property, _valueFormatter);

            builder.AddValue(mapper, provider);
        }

        TextSlice Single(TextSlice slice, int position)
        {
            TextSlice result;
            slice.TryGetSlice(position, out result);

            return result ?? Slice.Missing;
        }

        protected override IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }
    }
}