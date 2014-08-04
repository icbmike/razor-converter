namespace Olympic.RazorConverter.WebForms.DOM
{
    public interface IWebFormsDirectiveNode : IWebFormsNode
    {
        DirectiveType Directive { get; }
    }
}
