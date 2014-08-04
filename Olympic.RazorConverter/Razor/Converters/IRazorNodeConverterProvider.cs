using Olympic.RazorConverter.Razor.DOM;

namespace Olympic.RazorConverter.Razor.Converters
{
    using System.Collections.Generic;
    using Olympic.RazorConverter.Razor.DOM;

    public interface IRazorNodeConverterProvider
    {
        IList<INodeConverter<IRazorNode>> NodeConverters { get; }
    }
}
