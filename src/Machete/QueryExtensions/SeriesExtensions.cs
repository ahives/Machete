﻿namespace Machete
{
    using System;
    using System.Collections.Generic;
    using Parsers;


    public static class SeriesExtensions
    {
        public static Parser<TInput, T> FirstOrDefault<TInput, T>(this Parser<TInput, T> parser, T defaultValue = default(T))
        {
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));

            return new FirstOrDefaultParser<TInput, T>(parser, defaultValue);
        }

        /// <summary>
        /// Returns a parsed element as a singular array instead of a single element.
        /// </summary>
        public static Parser<TInput, IReadOnlyCollection<T>> One<TInput, T>(this Parser<TInput, T> parser)
        {
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));

            return new OneParser<TInput, T>(parser);
        }

        /// <summary>
        /// Returns a series of parsed elements as an array as long as there are one or more elements.
        /// </summary>
        public static Parser<TInput, IReadOnlyCollection<T>> OneOrMore<TInput, T>(this Parser<TInput, T> parser)
        {
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));

            return new SeriesParser<TInput, T>(parser, true);
        }

        /// <summary>
        /// Returns a series of parsed elements as an array.
        /// </summary>
        public static Parser<TInput, IReadOnlyCollection<T>> ZeroOrMore<TInput, T>(this Parser<TInput, T> parser)
        {
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));

            return new SeriesParser<TInput, T>(parser, false);
        }

        /// <summary>
        /// Take exactly the number of elements specified from the document starting from the current position of the cursor.
        /// </summary>
        public static Parser<TInput, IReadOnlyCollection<T>> Take<TInput, T>(this Parser<TInput, T> parser, int count)
        {
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be >= 0");

            return new TakeParser<TInput, T>(parser, count);
        }
    }
}