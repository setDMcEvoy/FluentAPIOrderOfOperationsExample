using System;
using System.Data.Common;

namespace FluentAPIOrderOfOperationsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Creates an order in your online cart at your store
            var buyStuff = Order.CreateOrder()
                .AtStore("StoreName")
                .ForTime(DateTime.Now)
                .ForUser("moi")
                .WithPassword("SuperSecretInPlainText")
                .AddItem("Junk Food")
                .AddItem("Lettuce")
                .Submit();

            //Order.CreateOrder().AtStore("").ForTime("").ForUser("").WithPassword("").
        }
    }
}
