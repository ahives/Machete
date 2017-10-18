namespace Machete.SchemaConfiguration.Configurators
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Builders;
    using Configuration;
    using Internals.Algorithms;
    using Internals.Extensions;
    using TypeSelectors;


    public class SchemaConfigurator<TSchema, TLayout> :
        ISchemaConfigurator<TSchema>,
        ISchemaLayoutConfigurator<TSchema, TLayout>,
        ISpecification
        where TSchema : Entity
        where TLayout : Layout
    {
        readonly IDictionary<Type, ISchemaSpecification<TSchema>> _schemaSpecifications;
        readonly IDictionary<Type, ILayoutSpecification<TSchema, TLayout>> _layoutSpecifications;
        readonly IEntitySelectorFactory _entitySelectorFactory;

        protected IEntitySelectorFactory EntitySelectorFactory => _entitySelectorFactory;

        protected SchemaConfigurator(IEntitySelectorFactory entitySelectorFactory)
        {
            _entitySelectorFactory = entitySelectorFactory;

            _schemaSpecifications = new Dictionary<Type, ISchemaSpecification<TSchema>>();
            _layoutSpecifications = new Dictionary<Type, ILayoutSpecification<TSchema, TLayout>>();
        }

        public void Add(ISchemaSpecification<TSchema> specification)
        {
            if (specification == null)
                throw new ArgumentNullException(nameof(specification));

            _schemaSpecifications.Add(specification.EntityType, specification);
        }

        public void Add(ILayoutSpecification<TSchema, TLayout> specification)
        {
            if (specification == null)
                throw new ArgumentNullException(nameof(specification));

            _layoutSpecifications.Add(specification.TemplateType, specification);
        }

        public void AddFromNamespaceContaining<T>()
        {
            string ns = typeof(T).Namespace;
            if (ns == null)
                throw new ArgumentException("The specified type does not have a valid namespace", nameof(T));

            var types = typeof(T).GetTypeInfo().Assembly.GetTypes()
                .Where(x => x.Namespace != null && x.Namespace.StartsWith(ns))
                .ToList();

            AddSchemaSpecifications(types);
            AddLayoutSpecifications(types);
        }

        void AddSchemaSpecifications(IEnumerable<Type> namespaceTypes)
        {
            var specificationTypes = namespaceTypes
                .Where(x => x.HasInterface<ISchemaSpecification<TSchema>>())
                .Where(x => x.IsConcrete());

            foreach (var type in specificationTypes)
            {
                var specification = (ISchemaSpecification<TSchema>) Activator.CreateInstance(type);

                _schemaSpecifications.Add(specification.EntityType, specification);
            }
        }
        void AddLayoutSpecifications(IEnumerable<Type> namespaceTypes)
        {
            var types = namespaceTypes
                .Where(x => x.HasInterface<ILayoutSpecification<TSchema, TLayout>>())
                .Where(x => x.IsConcrete());

            foreach (var type in types)
            {
                var specification = (ILayoutSpecification<TSchema, TLayout>) Activator.CreateInstance(type);

                _layoutSpecifications.Add(specification.TemplateType, specification);
            }
        }

        public IEnumerable<ValidateResult> Validate()
        {
            return _schemaSpecifications.Values.SelectMany(x => x.Validate())
                .Concat(_layoutSpecifications.Values.SelectMany(x => x.Validate()));
        }

        public ISchema<TSchema> Build()
        {
            var builder = CreateSchemaBuilder();

            BuildSchema(builder);

            BuildLayouts(builder);

            return builder.Build();
        }

        protected virtual SchemaBuilder<TSchema> CreateSchemaBuilder()
        {
            return new SchemaBuilder<TSchema>(EntitySelectorFactory);
        }

        void BuildSchema(ISchemaBuilder<TSchema> builder)
        {
            var graph = new DependencyGraph<Type>();
            foreach (var specification in _schemaSpecifications)
            {
                foreach (var entityType in specification.Value.GetReferencedEntityTypes())
                {
                    graph.Add(specification.Key, entityType);
                }
            }

            var orderedSpecifications = graph.GetItemsInDependencyOrder()
                .Concat(_schemaSpecifications.Keys)
                .Distinct()
                .Select(type => _schemaSpecifications[type]);

            foreach (var specification in orderedSpecifications)
            {
                specification.Apply(builder);
            }
        }


        void BuildLayouts(ISchemaLayoutBuilder<TSchema> schemaBuilder)
        {
            var builder = new SchemaLayoutBuilder<TSchema>(schemaBuilder);

            var graph = new DependencyGraph<Type>();
            foreach (var specification in _layoutSpecifications)
            {
                foreach (var layoutType in specification.Value.GetReferencedLayoutTypes())
                {
                    graph.Add(specification.Key, layoutType);
                }
            }

            var orderedSpecifications = graph.GetItemsInDependencyOrder()
                .Concat(_layoutSpecifications.Keys)
                .Distinct()
                .Select(type => _layoutSpecifications[type]);

            foreach (var specification in orderedSpecifications)
            {
                specification.Apply(builder);
            }
        }
    }
}