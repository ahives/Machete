namespace Machete.SchemaConfiguration
{
    using System;
    using System.Collections.Generic;
    using Configuration;


    public interface ILayoutSpecification<TSchema, TLayout> :
        ISpecification
        where TSchema : Entity
    where TLayout : Layout
    {
        Type TemplateType { get; }

        IEnumerable<Type> GetReferencedLayoutTypes();

        void Apply(ISchemaLayoutBuilder<TSchema> builder);

        void Apply(ILayoutFormatterBuilder<TLayout> builder);
    }


    public interface ILayoutFormatterBuilder<T>
        where T : Layout
    {
        void Format(LayoutFormatContext<T> context);
    }
}