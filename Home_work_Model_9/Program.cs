using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Home_work_Model_9
{
    public abstract class Beverage
    {
        public abstract string Description();
        public abstract double Cost();

    }

    public class Coffee : Beverage
    {
        public override string Description()
        {
            return "Coffee";
        }
        public override double Cost()
        {
            return 1.0;
        }
    }

    public class Latte : Beverage
    {
        public override string Description()
        {
            return "Latte";
        }
        public override double Cost()
        {
            return 3.5;
        }
    }

    public class Americano : Beverage
    {
        public override string Description()
        {
            return "Americano";
        }
        public override double Cost()
        {
            return 1.6;
        }
    }

    public class Mocha : Beverage
    {
        public override string Description()
        {
            return "Mocha";
        }
        public override double Cost()
        {
            return 2.5;
        }
    }
    public abstract class BeverageDecarator : Beverage
    {
        protected Beverage beverage;

        public BeverageDecarator(Beverage beverage)
        {
            this.beverage = beverage;
        }
    }

    public class MilkDecorator : BeverageDecarator
    {
        public MilkDecorator(Beverage beverage) : base(beverage) { }

        public override string Description()
        {
            return beverage.Description() + ", Milk";
        }
        public override double Cost()
        {
            return beverage.Cost() + 0.2;

        }
    }

    public class WhippedCreamDecorator : BeverageDecarator
    {
        public WhippedCreamDecorator(Beverage beverage) : base(beverage) { }

        public override string Description()
        {
            return beverage.Description() + ", Whipped Cream";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.5;
        }
    }
    public class SugarDecorator : BeverageDecarator
    {
        public SugarDecorator(Beverage beverage) : base(beverage) { }

        public override string Description()
        {
            return beverage.Description() + ", Sugar";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.1;
        }
    }

    public class ChocolateDecorator : BeverageDecarator
    {
        public ChocolateDecorator(Beverage beverage) : base(beverage) { }

        public override string Description()
        {
            return beverage.Description() + ", Chocolate";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Создание напитка Coffee с добавками
            Beverage beverage = new Coffee();
            beverage = new MilkDecorator(beverage);
            beverage = new WhippedCreamDecorator(beverage);
            Console.WriteLine($"{beverage.Description()} - Cost: ${beverage.Cost()}");

            // Создание напитка Latte с добавками
            Beverage latte = new Latte();
            latte = new SugarDecorator(latte);
            latte = new ChocolateDecorator(latte);
            Console.WriteLine($"{latte.Description()} - Cost: ${latte.Cost()}");

            // Создание напитка Mocha с добавками
            Beverage mocha = new Mocha();
            mocha = new MilkDecorator(mocha);
            mocha = new WhippedCreamDecorator(mocha);
            mocha = new ChocolateDecorator(mocha);
            Console.WriteLine($"{mocha.Description()} - Cost: ${mocha.Cost()}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
