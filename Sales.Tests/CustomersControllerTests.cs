using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales.API.Controllers;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Tests
{
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CustomersController _controller;

        public CustomersControllerTests()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _mockOrderService = new Mock<IOrderService>();
            _mockMapper = new Mock<IMapper>();

            // Initializing the controller with mocked dependencies
            _controller = new CustomersController(_mockCustomerService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnCustomersWithPredictions()
        {
            // Arrange
            List<CustomerResponseDto> mockCustomers =
            [
                new CustomerResponseDto { CustId = 1, CompanyName = "Customer1" },
                new CustomerResponseDto { CustId = 2, CompanyName = "Customer2" }
            ];

            List<OrderNextPredictedDto> mockOrders =
            [
                new OrderNextPredictedDto { CustId = 1, NextPredictedOrder = DateTime.Now.AddDays(5) },
                new OrderNextPredictedDto { CustId = 2, NextPredictedOrder = DateTime.Now.AddDays(10) }
            ];

            _mockCustomerService.Setup(service => service.GetAllAsync()).ReturnsAsync(mockCustomers);
            _mockOrderService.Setup(service => service.GetAllOrderNextPredictedAsync(It.IsAny<string?>())).ReturnsAsync(mockOrders);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<CustomerResponseDto>>(mockCustomers))
                .Returns(mockCustomers.Select(c => new CustomerResponseDto { CustId = c.CustId, CompanyName = c.CompanyName }));

            // Act
            ActionResult<IEnumerable<CustomerResponseDto>> result = await _controller.GetAll();

            // Assert
            ActionResult<IEnumerable<CustomerResponseDto>> actionResult = Assert.IsType<ActionResult<IEnumerable<CustomerResponseDto>>>(result);
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            IEnumerable<CustomerResponseDto> customers = Assert.IsType<IEnumerable<CustomerResponseDto>>(okResult.Value, exactMatch: false);

            // Verifying that the customers are returned as expected
            Assert.Equal(2, customers.Count());
            Assert.Equal("Customer1", customers.First().CompanyName);
            Assert.Equal("Customer2", customers.Last().CompanyName);

            // Ensure that the prediction logic was applied correctly
            Assert.Equal(DateTime.Now.AddDays(5).Date.ToString("yyyy-MM-dd"), customers.First().NextPredictedOrder?.Date.ToString("yyyy-MM-dd"));
            Assert.Equal(DateTime.Now.AddDays(10).Date.ToString("yyyy-MM-dd"), customers.Last().NextPredictedOrder?.Date.ToString("yyyy-MM-dd"));
        }
    }
}
