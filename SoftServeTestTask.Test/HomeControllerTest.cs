using SoftServeTestTask.Controllers;
using System;
using Xunit;


namespace SoftServeTestTask.Test
{
    public class HomeControllerTest
    {
        public HomeControllerTest()
        {

        }

        [Fact(DisplayName = "Index should return default view")]
        public void Index_should_return_default_view()
        {
            //var controller = new HomeController();
            //var viewResult = (Action)controller.Index();
            //var viewName = viewResult.ViewName;

            //Assert.True(string.IsNullOrEmpty(viewName) || viewName == "Index");
        }

        [Fact(DisplayName = "Failing test")]
        public void ShouldFail()
        {
            throw new NotImplementedException();
        }
    }
}
