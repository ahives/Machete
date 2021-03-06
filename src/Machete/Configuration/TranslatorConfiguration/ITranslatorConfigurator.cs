﻿namespace Machete.TranslatorConfiguration
{
    public interface ITranslatorConfigurator<TSchema>
        where TSchema : Entity
    {
        string Name { set; }
        
        void Add(ITranslatorSpecification<TSchema> specification);
    }
}