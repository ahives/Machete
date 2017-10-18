namespace Machete.HL7.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class HL7LayoutFormatter<TLayout> :
        ILayoutFormatter<TLayout>
    where TLayout : HL7Layout
    {
        readonly ILayoutPropertyFormatter<TLayout>[] _formatters;

        public HL7LayoutFormatter(IEnumerable<ILayoutPropertyFormatter<TLayout>> formatters)
        {
            _formatters = formatters.ToArray();
        }

        public void Format(FormatContext context, TLayout layout)
        {
            for (int i = 0; i < _formatters.Length; i++)
            {
//                _formatters[i].Format(layout);
            }
            throw new NotImplementedException();
        }

        public Type LayoutType { get; }

        public void Format<T>(FormatContext context, T layout)
            where T : Layout
        {
            throw new NotImplementedException();
        }
    }
}