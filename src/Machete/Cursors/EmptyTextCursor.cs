﻿namespace Machete.Cursors
{
    using System;
    using System.Threading.Tasks;
    using Texts;


    public class EmptyTextCursor :
        TextCursor
    {
        readonly StreamText _sourceText;
        readonly TextSpan _remainingSpan;

        public EmptyTextCursor(StreamText text, TextSpan span)
        {
            _sourceText = text;
            _remainingSpan = span;
        }

        public bool HasValue => false;
        public bool HasNext => false;

        public ParseText Text => ParseText.Empty;
        public TextSpan Span => TextSpan.Empty;

        Task<TextCursor> TextCursor.Next()
        {
            throw new InvalidOperationException("There is no next, the cursor is empty");
        }

        StreamText TextCursor.SourceText => _sourceText;
        TextSpan TextCursor.RemainingSpan => _remainingSpan;
    }
}