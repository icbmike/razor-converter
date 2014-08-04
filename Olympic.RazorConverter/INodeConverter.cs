using Olympic.RazorConverter.WebForms.DOM;

namespace Olympic.RazorConverter
{
    using System.Collections.Generic;
    using Olympic.RazorConverter.WebForms.DOM;

    public interface INodeConverter<TOut>
    {
        IList<TOut> ConvertNode(IWebFormsNode node);
        bool CanConvertNode(IWebFormsNode node);
    }
}
