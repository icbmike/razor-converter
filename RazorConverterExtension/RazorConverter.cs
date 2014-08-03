using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Telerik.RazorConverter;
using Telerik.RazorConverter.Razor.DOM;

namespace OlympicSoftware.RazorConverterExtension
{
    public class RazorConverter
    {
        public RazorConverter()
        {
            var catalog = new AssemblyCatalog(typeof(IWebFormsParser).Assembly);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        [Import]
        private IWebFormsParser Parser
        {
            get;
            set;
        }

        [Import]
        private IWebFormsConverter<IRazorNode> Converter
        {
            get;
            set;
        }

        [Import]
        private IRenderer<IRazorNode> Renderer
        {
            get;
            set;
        }

        public string ConvertAspx(string aspxFileName)
        {
            var document = Parser.Parse(File.ReadAllText(aspxFileName));
            
            var razorDom = Converter.Convert(document);
            
            return Renderer.Render(razorDom);
        }
    }
}