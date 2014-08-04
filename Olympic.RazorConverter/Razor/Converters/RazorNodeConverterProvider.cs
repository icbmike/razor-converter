using Olympic.RazorConverter.Razor.DOM;

namespace Olympic.RazorConverter.Razor.Converters
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using Olympic.RazorConverter;
    using Olympic.RazorConverter.Razor.DOM;

    [Export(typeof(IRazorNodeConverterProvider))]
    public class RazorNodeConverterProvider : IRazorNodeConverterProvider
    {
        [ImportingConstructor]
        public RazorNodeConverterProvider(  IRazorDirectiveNodeFactory directiveNodeFactory,
                                            IRazorSectionNodeFactory sectionNodeFactory,
                                            IRazorCodeNodeFactory codeNodeFactory,
                                            IRazorTextNodeFactory textNodeFactory,
                                            IRazorCommentNodeFactory commentNodeFactory,
                                            IRazorExpressionNodeFactory expressionNodeFactory,
                                            IContentTagConverterConfiguration contentTagConverterConfig)
        {
            NodeConverters = new INodeConverter<IRazorNode>[] {
                new DirectiveConverter(directiveNodeFactory),
                new ContentTagConverter(this, sectionNodeFactory, contentTagConverterConfig),
                new CodeGroupConverter(this),
                new CodeBlockConverter(codeNodeFactory),
                new TextNodeConverter(textNodeFactory),
                new CommentNodeConverter(commentNodeFactory),
                new ExpressionBlockConverter(expressionNodeFactory)
            };
        }

        public IList<INodeConverter<IRazorNode>> NodeConverters
        {
            get;
            private set;
        }
    }
}
