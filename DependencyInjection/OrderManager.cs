using System;

namespace DependencyInjection
{
	public class OrderManager
	{
		public void Submit(Product product, string creditCardNumber, string expiryDate)
		{
			Console.WriteLine($"Product: {product}, Number: {creditCardNumber}, Expiry: {expiryDate}");
		}
	}
}
