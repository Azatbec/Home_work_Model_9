using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_work_Model_9_2
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    public class PayPaymentProcessor : IPaymentProcessor
    { 
        public void ProcessPayment(double amount) 
        {
            Console.Write($"Processing payment of ${amount} through PayPal.");
        }
    }

    public class StripePaymentService
    {
        public void MakeTransaction(double totalAmount)
        {
            Console.WriteLine($"Processing payment of ${totalAmount} through Stripe.");
            // Логика обработки платежа через Stripe
        }
    }

    public class StripePaymentAdapter : IPaymentProcessor
    {
        private readonly StripePaymentService _stripeService;

        public StripePaymentAdapter(StripePaymentService stripeService)
        {
            _stripeService = stripeService;
        }

        public void ProcessPayment(double amount)
        {
            _stripeService.MakeTransaction(amount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Создание платежного процессора PayPal и его использование
            IPaymentProcessor paypalProcessor = new PayPaymentProcessor();
            paypalProcessor.ProcessPayment(100.0);

            // Создание адаптера для StripePaymentService и его использование
            StripePaymentService stripeService = new StripePaymentService();
            IPaymentProcessor stripeAdapter = new StripePaymentAdapter(stripeService);
            stripeAdapter.ProcessPayment(150.0);

            Console.WriteLine("Payments processed successfully.");
            Console.ReadKey();
        }
    }
}
