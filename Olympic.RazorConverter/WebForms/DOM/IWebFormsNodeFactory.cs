using Olympic.RazorConverter.WebForms.DOM;

namespace Olympic.RazorConverter.WebForms.Parsing
{
    using System.Text.RegularExpressions;
    using Olympic.RazorConverter.WebForms.DOM;   

    public interface IWebFormsNodeFactory
    {
        IWebFormsNode CreateNode(Match match, NodeType type);
    }
}
