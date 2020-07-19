using System;

namespace DependencyInjection
{
	public interface IOrderManager
	{
		void Submit(Product product, string creditCardNumber, string expiryDate);
	}
	public class OrderManager : IOrderManager
	{
		private readonly IProductStockRepository _productStockRepository;
		private readonly IPaymentProcessor _paymentProcessor;
		private readonly IShippingProcessor _shippingProcessor;

		public OrderManager(IProductStockRepository productStockRepository, IPaymentProcessor paymentProcessor, IShippingProcessor shippingProcessor)
		{
			_productStockRepository = productStockRepository;
			_paymentProcessor = paymentProcessor;
			_shippingProcessor = shippingProcessor;
		}
		public void Submit(Product product, string creditCardNumber, string expiryDate)
		{
			// Check product stock
			if (!_productStockRepository.IsInStock(product))
			{
				throw new Exception($"{product} currently not in stock");
			}
			Console.WriteLine("Product in stock, Processing payment now");

			// Payment
			_paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);
			Console.WriteLine("Payment verifies, Processing shipment now");

			// Ship the product
			_shippingProcessor.MailProduct(product);
			Console.WriteLine($"{product} is shipped");
		}
	}
}
