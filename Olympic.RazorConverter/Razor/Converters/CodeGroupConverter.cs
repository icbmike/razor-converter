using Olympic.RazorConverter.Razor.DOM;
using Olympic.RazorConverter.WebForms.DOM;

namespace Olympic.RazorConverter.Razor.Converters
{
    using System.Collections.Generic;
    using Olympic.RazorConverter;
    using Olympic.RazorConverter.Razor.DOM;
    using Olympic.RazorConverter.WebForms.DOM;

    public class CodeGroupConverter : INodeConverter<IRazorNode>
    {
        private IRazorNodeConverterProvider NodeConverterProvider
        {
            get;
            set;
        }

        public CodeGroupConverter(IRazorNodeConverterProvider converterProvider)
        {
            NodeConverterProvider = converterProvider;
        }

        public IList<IRazorNode> ConvertNode(IWebFormsNode node)
        {
            var result = new List<IRazorNode>();

            foreach (var childNode in node.Children)
            {
                foreach (var converter in NodeConverterProvider.NodeConverters)
                {
                    if (converter.CanConvertNode(childNode))
                    {
                        foreach (var convertedChildNode in converter.ConvertNode(childNode))
                        {
                            result.Add(convertedChildNode);
                        }
                    }
                }
            }

            return result;
        }

        public bool CanConvertNode(IWebFormsNode node)
        {
            return node as IWebFormsCodeGroupNode != null;
        }
    }
}
