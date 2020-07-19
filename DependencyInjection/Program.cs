using System;

namespace DependencyInjection
{
	class Program
	{
		static void Main(string[] args)
		{
			var product = string.Empty;
			var orderManager = new OrderManager();
			while (product != "exit")
			{
				Console.WriteLine(@"Enter a Product: 
Keyboard = 0,
Mouse = 1,
Mic = 2,
Speaker = 3"
				);
				product = Console.ReadLine();

				try
				{
					if (Enum.TryParse(product, out Product productEnum))
					{
						Console.WriteLine("Please enter a valid payment method: XXXXXXXXXXXXXXXX;MMYY");
						var paymentMethod = Console.ReadLine();
						if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(";").Length != 2)
						{
							throw new Exception("Invalid Payment Method");
						}
						string creditCardNumber = paymentMethod.Split(";")[0];
						string expiryDate = paymentMethod.Split(";")[1];
						orderManager.Submit(productEnum, creditCardNumber, expiryDate);
						Console.WriteLine("DONE");

					}
					else
					{
						Console.WriteLine("Invalid Product");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				Console.WriteLine(Environment.NewLine);
			}
		}
	}
}
