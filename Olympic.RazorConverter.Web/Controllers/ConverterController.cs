using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Mvc;
using Olympic.RazorConverter.Web.Models;
using Telerik.RazorConverter;
using Telerik.RazorConverter.Razor.DOM;

namespace Olympic.RazorConverter.Web.Controllers
{
    public class ConverterController : Controller
    {

        public ConverterController()
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

        // GET: Converter
        public ActionResult Index()
        {
            return View(new ConverterModel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(ConverterModel model)
        {
            var document = Parser.Parse(model.Input);
            var razorDom = Converter.Convert(document);
            var razorPage = Renderer.Render(razorDom);

            model.Output = razorPage;


            return View(model);

        }
    }
}