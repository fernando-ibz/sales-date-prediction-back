using Moq;
using Sales.API.Controllers;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sales.Tests
{
    public class OrdersControllerTests
    {
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly Mock<IOrderDetailService> _mockOrderDetailService;
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly OrdersController _controller;

        public OrdersControllerTests()
        {
            _mockOrderService = new Mock<IOrderService>();
            _mockCustomerService = new Mock<ICustomerService>();
            _mockOrderDetailService = new Mock<IOrderDetailService>();
            _mockMapper = new Mock<IMapper>();

            // Initializing the controller with mocked dependencies
            _controller = new OrdersController(_mockOrderService.Object, _mockOrderDetailService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetOrdersByCustomer_ShouldReturnOrders()
        {
            // Arrange
            List<Order> mockOrders =
            [
                new() { OrderId = 1, ShipName = "Order1", ShipCity = "City1", OrderDate = DateTime.Now },
                new() { OrderId = 2, ShipName = "Order2", ShipCity = "City2", OrderDate = DateTime.Now.AddDays(1) }
            ];

            List<OrderResponseDto> mockOrderDtos =
            [
                new() { OrderId = 1, ShipName = "Order1", ShipCity = "City1" },
                new() { OrderId = 2, ShipName = "Order2", ShipCity = "City2" }
            ];

            _mockOrderService.Setup(service => service.GetAllbyCustomer(It.IsAny<int>()))
                .ReturnsAsync(mockOrders);

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<OrderResponseDto>>(mockOrders))
                .Returns(mockOrderDtos);

            // Act
            var result = await _controller.GetByCustomerId(1);

            // Assert
            ActionResult<IEnumerable<OrderResponseDto>> actionResult = Assert.IsType<ActionResult<IEnumerable<OrderResponseDto>>>(result);
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            IEnumerable<OrderResponseDto> orders = Assert.IsType<IEnumerable<OrderResponseDto>>(okResult.Value, exactMatch: false);

            // Verifying that the orders are returned as expected
            Assert.Equal(2, orders.Count());
            Assert.Equal("Order1", orders.First().ShipName);
            Assert.Equal("Order2", orders.Last().ShipName);
        }
    }
}
