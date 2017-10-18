namespace Machete.SchemaConfiguration
{
    public interface ISchemaLayoutConfigurator<TSchema, TLayout>
        where TSchema : Entity
    where TLayout : Layout
    {
        /// <summary>
        /// Add a template
        /// </summary>
        /// <param name="specification"></param>
        void Add(ILayoutSpecification<TSchema, TLayout> specification);

        /// <summary>
        /// Add the templates found in the namespace containing the specified type.
        /// </summary>
        /// <typeparam name="T">The search type</typeparam>
        void AddFromNamespaceContaining<T>();
    }
}