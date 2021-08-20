namespace SunnyFarm.Test.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Controllers;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Error();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
