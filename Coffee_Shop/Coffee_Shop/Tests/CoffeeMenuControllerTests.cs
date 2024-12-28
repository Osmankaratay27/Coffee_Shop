using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Coffee_Shop.Controllers;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Coffee_Shop.Tests
{
    public class CoffeeMenuControllerTests
    {
        private readonly Mock<ICoffeeMenuDal> _mockCoffeeMenuDal;
        private readonly CoffeeMenuManager _coffeeMenuManager;
        private readonly CoffeeMenuController _controller;

        public CoffeeMenuControllerTests()
        {
            _mockCoffeeMenuDal = new Mock<ICoffeeMenuDal>();
            _coffeeMenuManager = new CoffeeMenuManager(_mockCoffeeMenuDal.Object);
        //    _controller = new CoffeeMenuController(_coffeeMenuManager);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithCoffeeMenuList()
        {
            // Arrange
            var coffeeMenus = new List<CoffeeMenu>
            {
                new CoffeeMenu { CoffeeMenuName = "Espresso", CoffeeMenuPrice = 10 },
                new CoffeeMenu { CoffeeMenuName = "Latte", CoffeeMenuPrice = 15 }
            };
            _mockCoffeeMenuDal.Setup(d => d.GetListAll()).Returns(coffeeMenus);

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal(coffeeMenus, result.Model);
        }

        [Fact]
        public void Add_ValidModel_ReturnsRedirectToIndex()
        {
            // Arrange
            var coffeeMenu = new CoffeeMenu { CoffeeMenuName = "Cappuccino", CoffeeMenuPrice = 12 };
            _mockCoffeeMenuDal.Setup(d => d.Add(It.IsAny<CoffeeMenu>()));

            var fileMock = new Mock<IFormFile>();
            var content = "Fake file content";
            var fileName = "coffee.jpg";
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(content);
            writer.Flush();
            memoryStream.Position = 0;
            fileMock.Setup(f => f.OpenReadStream()).Returns(memoryStream);
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.Length).Returns(memoryStream.Length);

            // Act
            var result = _controller.Add(coffeeMenu, fileMock.Object) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Delete_ExistingCoffeeMenu_RedirectsToIndex()
        {
            // Arrange
            var coffeeMenu = new CoffeeMenu { CoffeeMenuName = "Espresso", CoffeeMenuPrice = 5.7 };
            _mockCoffeeMenuDal.Setup(repo => repo.GetListAll().Where(x => x.CoffeeMenuName == "Espresso").FirstOrDefault()).Returns(coffeeMenu);

            // Act
            var result = _controller.Delete("Espresso");

            // Assert
            _mockCoffeeMenuDal.Verify(repo => repo.Delete(coffeeMenu), Times.Once);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Update_ValidModel_ReturnsRedirectToIndex()
        {
            // Arrange
            var coffeeMenu = new CoffeeMenu { CoffeeMenuName = "Mocha", CoffeeMenuPrice = 18 };
            _mockCoffeeMenuDal.Setup(d => d.Update(It.IsAny<CoffeeMenu>()));

            var fileMock = new Mock<IFormFile>();
            var content = "Fake file content";
            var fileName = "mocha.jpg";
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(content);
            writer.Flush();
            memoryStream.Position = 0;
            fileMock.Setup(f => f.OpenReadStream()).Returns(memoryStream);
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.Length).Returns(memoryStream.Length);

            // Act
            var result = _controller.Update(coffeeMenu, fileMock.Object) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
    }
}
