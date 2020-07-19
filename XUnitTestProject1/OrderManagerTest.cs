using DependencyInjection;
using System;
using Xunit;

namespace DependencyInjectionTest
{
	public class OrderManagerTest
	{
		[Fact]
		public void Test1()
		{
			var orderManager = new OrderManager();
			orderManager.Submit(Product.Keyboard, "1234", "1234");
			Assert.ThrowsAny<Exception>(() => orderManager.Submit(Product.Keyboard, "1234", "1234"));
		}
	}
}
