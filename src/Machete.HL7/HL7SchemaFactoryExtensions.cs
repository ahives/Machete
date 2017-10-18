namespace Machete.HL7
{
    using System;
    using Machete;
    using Machete.Configuration;
    using SchemaConfiguration;
    using SchemaConfiguration.Configurators;


    public static class HL7SchemaFactoryExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="configure"></param>
        /// <typeparam name="TSchema"></typeparam>
        /// <typeparam name="TLayout"></typeparam>
        /// <returns></returns>
        /// <exception cref="SchemaConfigurationException"></exception>
        public static ISchema<TSchema> CreateHL7<TSchema, TLayout>(this ISchemaFactorySelector selector, Action<IHL7SchemaConfigurator<TSchema>> configure = null)
            where TSchema : HL7Entity
            where TLayout : HL7Layout
        {
            var configurator = new HL7SchemaConfigurator<TSchema, TLayout>();

            configure?.Invoke(configurator);

            configurator.ValidateSpecification();

            try
            {
                return configurator.Build();
            }
            catch (Exception exception)
            {
                throw new SchemaConfigurationException("The HL7 schema could not be built (see InnerException for details).", exception);
            }
        }
    }
}