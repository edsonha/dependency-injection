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

			Console.WriteLine($"{product} in stock");

			// Payment

			// Ship the product
		}
	}
}
