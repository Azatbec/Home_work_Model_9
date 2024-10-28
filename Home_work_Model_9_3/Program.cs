using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_work_Model_9_3
{
    
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing payment of ${amount} through PayPal.");
            // Логика обработки платежа через PayPal
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

    
    public class SquarePaymentService
    {
        public void ProcessSquarePayment(double amount, string currency)
        {
            Console.WriteLine($"Processing payment of {amount} {currency} through Square.");
            // Логика обработки платежа через Square
        }
    }

       public class SquarePaymentAdapter : IPaymentProcessor
    {
        private readonly SquarePaymentService _squareService;

        public SquarePaymentAdapter(SquarePaymentService squareService)
        {
            _squareService = squareService;
        }

        public void ProcessPayment(double amount)
        {
            // Адаптер конвертирует вызов ProcessPayment в вызов ProcessSquarePayment с валютой USD
            _squareService.ProcessSquarePayment(amount, "USD");
        }
    }

     class Program
    {
        static void Main(string[] args)
        {
            // Использование PayPal
            IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
            paypalProcessor.ProcessPayment(100.0);

            // Использование Stripe через адаптер
            StripePaymentService stripeService = new StripePaymentService();
            IPaymentProcessor stripeAdapter = new StripePaymentAdapter(stripeService);
            stripeAdapter.ProcessPayment(150.0);

            // Использование Square через адаптер
            SquarePaymentService squareService = new SquarePaymentService();
            IPaymentProcessor squareAdapter = new SquarePaymentAdapter(squareService);
            squareAdapter.ProcessPayment(200.0);

            Console.WriteLine("Payments processed successfully.");
            Console.ReadKey();
        }
    }
}
