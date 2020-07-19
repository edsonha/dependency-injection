using System;

namespace DependencyInjection
{
	public class ShippingProcessor
	{
		public void MailProduct(Product product)
		{
			var productStockRepository = new ProductStockRepository();
			productStockRepository.ReduceStock(product);
			Console.WriteLine("Call to Shipping API");
		}
	}
}
