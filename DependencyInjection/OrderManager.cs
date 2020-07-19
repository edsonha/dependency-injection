using System;

namespace DependencyInjection
{
	public class OrderManager
	{
		public void Submit(Product product, string creditCardNumber, string expiryDate)
		{
			// Check product stock
			var productStockRepository = new ProductStockRepository();
			if (!productStockRepository.IsInStock(product))
			{
				throw new Exception($"{product} currently not in stock");
			}
			Console.WriteLine("Product in stock, Processing payment now");

			// Payment
			var paymentProcessor = new PaymentProcessor();
			paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);

			// Ship the product
		}
	}
}
