namespace Olympic.RazorConverter
{
    public interface IRenderer<TNode>
    {
        string Render(IDocument<TNode> document);
    }
}
