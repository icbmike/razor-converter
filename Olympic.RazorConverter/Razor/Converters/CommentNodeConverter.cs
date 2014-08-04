using Olympic.RazorConverter.Razor.DOM;
using Olympic.RazorConverter.WebForms.DOM;

namespace Olympic.RazorConverter.Razor.Converters
{
    using System.Collections.Generic;
    using Olympic.RazorConverter.Razor.DOM;
    using Olympic.RazorConverter.WebForms.DOM;

    public class CommentNodeConverter : INodeConverter<IRazorNode>
    {
        private IRazorCommentNodeFactory CommentNodeFactory
        {
            get;
            set;
        }

        public CommentNodeConverter(IRazorCommentNodeFactory nodeFactory)
        {
            CommentNodeFactory = nodeFactory;
        }
        
        public IList<IRazorNode> ConvertNode(IWebFormsNode node)
        {
            var srcNode = node as IWebFormsCommentNode;
            var destNode = CommentNodeFactory.CreateCommentNode(srcNode.Text);
            return new IRazorNode[] { destNode };
        }

        public bool CanConvertNode(IWebFormsNode node)
        {
            return node is IWebFormsCommentNode;
        }
    }
}
