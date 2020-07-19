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
			Console.WriteLine("Payment verifies, Processing shipment now");

			// Ship the product
			var shippingProcessor = new ShippingProcessor();
			shippingProcessor.MailProduct(product);
			Console.WriteLine($"{product} is shipped");
		}
	}
}
