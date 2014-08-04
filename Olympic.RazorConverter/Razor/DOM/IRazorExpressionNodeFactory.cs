namespace Olympic.RazorConverter.Razor.DOM
{
    public interface IRazorExpressionNodeFactory
    {
        IRazorExpressionNode CreateExpressionNode(string expression, bool isMultiline);
    }
}
