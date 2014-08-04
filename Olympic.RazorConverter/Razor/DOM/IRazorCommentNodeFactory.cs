namespace Olympic.RazorConverter.Razor.DOM
{
    public interface IRazorCommentNodeFactory
    {
        IRazorCommentNode CreateCommentNode(string text);
    }
}
