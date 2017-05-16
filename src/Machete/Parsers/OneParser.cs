﻿namespace Machete.Parsers
{
    using System.Collections.Generic;


    /// <summary>
    /// Parses a single result and returns the match as a list with a single element
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class OneParser<TInput, T> :
        Parser<TInput, IReadOnlyList<T>>
    {
        readonly Parser<TInput, T> _parser;

        public OneParser(Parser<TInput, T> parser)
        {
            _parser = parser;
        }

        Result<Cursor<TInput>, IReadOnlyList<T>> Parser<TInput, IReadOnlyList<T>>.Parse(Cursor<TInput> input)
        {
            Result<Cursor<TInput>, T> result = _parser.Parse(input);
            if (result.HasValue)
                return new Success<Cursor<TInput>, IReadOnlyList<T>>(new[] {result.Value}, result.Next);

            return new Unmatched<Cursor<TInput>, IReadOnlyList<T>>(input);
        }
    }
}