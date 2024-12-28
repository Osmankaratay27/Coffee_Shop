using Coffee_Shop.Controllers;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using NuGet.ContentModel;

namespace Coffee_Shop.Tests
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly Mock<ICoffeeMenuService> _coffeeMenuServiceMock;
        private readonly Mock<IRegisterService> _registerServiceMock;
        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _coffeeMenuServiceMock = new Mock<ICoffeeMenuService>();
            _registerServiceMock = new Mock<IRegisterService>();

            _controller = new OrderController();
            // Kullanıcının kimlik bilgilerini simüle edin
            var httpContext = new DefaultHttpContext();
            httpContext.User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(
                new[] { new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "test@mail.com") }));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
        }

        [Fact]
        public void Index_ReturnsOrdersForCurrentUser()
        {
            // Arrange
            var orders = new List<Order>
        {
            new Order { OrderName = "Espresso", RegisterID = 1 },
            new Order { OrderName = "Latte", RegisterID = 1 }
        };

            _orderServiceMock.Setup(s => s.GetAllOrders())
                             .Returns(orders);

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Order>>(result.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_NewOrder_AddsOrderToDatabase()
        {
            // Arrange
            var coffeeMenu = new CoffeeMenu
            {
                CoffeeMenuName = "Espresso",
                CoffeeMenuPrice = 20.0,
                CoffeeMenuUrl = "/images/espresso.jpg"
            };

            _coffeeMenuServiceMock.Setup(s => s.GetAllCoffeeMenu())
                                  .Returns(new List<CoffeeMenu> { coffeeMenu });

            _orderServiceMock.Setup(s => s.AddOrder(It.IsAny<Order>()));

            // Act
            var result = _controller.Add("Espresso");

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            _orderServiceMock.Verify(s => s.AddOrder(It.IsAny<Order>()), Times.Once);
        }

        [Fact]
        public void Delete_ExistingOrder_DecreasesOrderCount()
        {
            // Arrange
            var order = new Order
            {
                OrderName = "Espresso",
                RegisterID = 1,
                OrderCount = 2,
                OrderPrice = 40.0
            };

            var coffeeMenu = new CoffeeMenu
            {
                CoffeeMenuName = "Espresso",
                CoffeeMenuPrice = 20.0
            };

            _orderServiceMock.Setup(s => s.GetAllOrders())
                             .Returns(new List<Order> { order });

            _coffeeMenuServiceMock.Setup(s => s.GetAllCoffeeMenu())
                                  .Returns(new List<CoffeeMenu> { coffeeMenu });

            _orderServiceMock.Setup(s => s.UpdateOrder(It.IsAny<Order>()));

            // Act
            var result = _controller.Delete("Espresso");

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(1, order.OrderCount);
            Assert.Equal(20.0, order.OrderPrice);
            _orderServiceMock.Verify(s => s.UpdateOrder(It.IsAny<Order>()), Times.Once);
        }

        [Fact]
        public void Add2_ExistingOrder_IncreasesOrderCount()
        {
            // Arrange
            var order = new Order
            {
                OrderName = "Latte",
                RegisterID = 1,
                OrderCount = 1,
                OrderPrice = 25.0
            };

            var coffeeMenu = new CoffeeMenu
            {
                CoffeeMenuName = "Latte",
                CoffeeMenuPrice = 25.0
            };

            _orderServiceMock.Setup(s => s.GetAllOrders())
                             .Returns(new List<Order> { order });

            _coffeeMenuServiceMock.Setup(s => s.GetAllCoffeeMenu())
                                  .Returns(new List<CoffeeMenu> { coffeeMenu });

            _orderServiceMock.Setup(s => s.UpdateOrder(It.IsAny<Order>()));

            // Act
            var result = _controller.Add2("Latte").Result;

            // Assert
            Assert.IsType<RedirectResult>(result);
            Assert.Equal(2, order.OrderCount);
            Assert.Equal(50.0, order.OrderPrice);
            _orderServiceMock.Verify(s => s.UpdateOrder(It.IsAny<Order>()), Times.Once);
        }
    }
}
