namespace Olympic.RazorConverter
{
    public interface IDocument<TNode>
    {
        TNode RootNode { get; }
    }
}
