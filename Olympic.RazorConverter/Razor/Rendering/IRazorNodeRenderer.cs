using Olympic.RazorConverter.Razor.DOM;

namespace Olympic.RazorConverter.Razor.Rendering
{
    using Olympic.RazorConverter.Razor.DOM;

    public interface IRazorNodeRenderer
    {
        string RenderNode(IRazorNode node);
        bool CanRenderNode(IRazorNode node);
    }
}
