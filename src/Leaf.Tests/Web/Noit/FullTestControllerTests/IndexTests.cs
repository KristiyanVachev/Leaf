using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void Index_ShouldCallServiceHasUnfinishedTest()
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();

            //Act
            var controller = new FullTestController(mockFullTestService.Object);

            //TODO Extract authentication
            //Assert
            //controller.WithCallTo(c => c.Index())
            //    .ShouldRenderView("FullTest");

        }
    }
}
