using Olympic.RazorConverter.WebForms.DOM;

namespace Olympic.RazorConverter
{
    using Olympic.RazorConverter.WebForms.DOM;

    public interface IWebFormsConverter<TNode>
    {
        IDocument<TNode> Convert(IDocument<IWebFormsNode> rootNode);
    }
}
