using Olympic.RazorConverter.WebForms.DOM;

namespace Olympic.RazorConverter
{
    using Olympic.RazorConverter.WebForms.DOM;

    public interface IWebFormsParser
    {
        IDocument<IWebFormsNode> Parse(string input);
    }
}
