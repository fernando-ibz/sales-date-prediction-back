using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales.API.Controllers;
using Sales.Application.Services;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Tests
{
    public class CustomersControllerTests
    {
        private readonly Mock<IRepository<Customer>> _mockRepository;

        public CustomersControllerTests()
        {
            _mockRepository = new Mock<IRepository<Customer>>();
        }

        [Fact]
        public async Task GetAll_ShouldReturnCustomersWithPredictions()
        {
            // Arrange
            List<Customer> mockCustomersEnt =
            [
                new Customer { CustId = 1, CompanyName = "Customer1" },
                new Customer { CustId = 2, CompanyName = "Customer2" }
            ];

            List<CustomerResponseDto> mockCustomersDto =
            [
                new CustomerResponseDto { CustId = 1, CompanyName = "Customer1" },
                new CustomerResponseDto { CustId = 2, CompanyName = "Customer2" }
            ];

            List<OrderNextPredictedDto> mockOrders =
            [
                new() { CustId = 1, NextPredictedOrder = DateTime.Now.AddDays(5) },
                new() { CustId = 2, NextPredictedOrder = DateTime.Now.AddDays(10) }
            ];

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockCustomersEnt);

            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(service => service.GetAllAsync()).ReturnsAsync(mockCustomersDto);

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(service => service.GetAllOrderNextPredictedAsync(It.IsAny<string?>())).ReturnsAsync(mockOrders);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<CustomerResponseDto>>(mockCustomersEnt))
                .Returns(mockCustomersDto.Select(c => new CustomerResponseDto { CustId = c.CustId, CompanyName = c.CompanyName }));

            var mockCustomerServiceObj = new CustomerService(_mockRepository.Object, mockOrderService.Object, mockMapper.Object);
            var controller = new CustomersController(mockCustomerServiceObj, mockMapper.Object);

            // Act
            ActionResult<IEnumerable<CustomerResponseDto>> result = await controller.GetAll();

            // Assert
            ActionResult<IEnumerable<CustomerResponseDto>> actionResult = Assert.IsType<ActionResult<IEnumerable<CustomerResponseDto>>>(result);
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            IEnumerable<CustomerResponseDto> customers = Assert.IsAssignableFrom<IEnumerable<CustomerResponseDto>>(okResult.Value);

            Assert.Equal(2, customers.Count());
            Assert.Equal("Customer1", customers.First().CompanyName);
            Assert.Equal("Customer2", customers.Last().CompanyName);
        }

    }
}
