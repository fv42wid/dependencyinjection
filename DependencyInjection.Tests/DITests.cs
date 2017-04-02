using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjection.Controllers;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DependencyInjection.Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            //Arrange
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(data);
            //TypeBroker.SetTestObject(mock.Object);
            HomeController controller = new HomeController(mock.Object);
            //Act
            ViewResult result = controller.Index();
            //Assert
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
