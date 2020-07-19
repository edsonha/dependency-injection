using DependencyInjection;
using Moq;
using System;
using Xunit;

namespace DependencyInjectionTests
{
	public class OrderManagerTests
	{
		[Fact]
		public void Test1()
		{
			var productStockRepositoryMock = new Mock<IProductStockRepository>();
			productStockRepositoryMock
				.Setup(m => m.IsInStock(It.IsAny<Product>())) //Or Product.Keyboard, etc
				.Returns(false);

			var paymentProcessorMock = new Mock<IPaymentProcessor>();
			var shippingProcessorMock = new Mock<IShippingProcessor>();

			var orderManager = new OrderManager(productStockRepositoryMock.Object, paymentProcessorMock.Object, shippingProcessorMock.Object);

			Assert.ThrowsAny<Exception>(() => orderManager.Submit(Product.Keyboard, "1234", "1234"));
		}
	}
}
