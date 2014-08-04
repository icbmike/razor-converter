using Olympic.RazorConverter.Razor.DOM;

namespace Olympic.RazorConverter.Tests.Razor.DOM
{
    using Olympic.RazorConverter.Razor.DOM;
    using Xunit;

    public class RazorCommentNodeFactoryTests
    {
        private readonly RazorCommentNodeFactory razorCommentNodeFactory;

        public RazorCommentNodeFactoryTests()
        {
            razorCommentNodeFactory = new RazorCommentNodeFactory();
        }

        [Fact]
        public void Should_set_text()
        {
            var commentNode = razorCommentNodeFactory.CreateCommentNode("text");
            commentNode.Text.ShouldEqual("text");
        }
    }
}
