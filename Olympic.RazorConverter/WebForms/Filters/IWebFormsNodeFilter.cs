using Olympic.RazorConverter.WebForms.DOM;

namespace Olympic.RazorConverter.WebForms.Filters
{
    using System.Collections.Generic;
    using Olympic.RazorConverter.WebForms.DOM;

    public interface IWebFormsNodeFilter
    {
        IList<IWebFormsNode> Filter(IWebFormsNode node, IWebFormsNode previousFilteredNode);
    }
}
