using System;

namespace Decorator
{

    public interface Icoffe
    {
        string GetDescription();

        double GetCoast();
    }

    public abstract class CondimentDecorator : Icoffe
    {
        Icoffe _coffe;
        protected double _price = 0.0;
        protected string _name;
        protected CondimentDecorator(Icoffe coffe)
        {
            _coffe = coffe;
        }

        public double GetCoast()
        {
            return _coffe.GetCoast() + _price;
        }

        public string GetDescription()
        {
            return $"{_coffe.GetDescription()} {_name}";
        }
    }

    public class MilkDecorator : CondimentDecorator
    {
        public MilkDecorator(Icoffe coffe) : base(coffe)
        {
            _name = "Leche";
            _price = 0.25;
        }
    }

    public class ChocolateDecorator : CondimentDecorator
    {
        public ChocolateDecorator(Icoffe coffe) : base(coffe)
        {
            _name = "Chocolate";
            _price = 0.45;
        }
    }

    public class Filtered: Icoffe
    {
        public string GetDescription()
        {
            return "Filtrado simple";
        }
        public double GetCoast()
        {
            return 5.65;
        }
    }

    public class Espresso: Icoffe
    {
        public string GetDescription()
        {
            return "Espresso simple";
        }
        public double GetCoast()
        {
            return 8.50;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DECORATOR" + '\n');
            Console.WriteLine("Permite añadir comportamiento a un objeto sin alterar su funcionamiento." + '\n');


            var expressoWithMilkAndChocolate = new MilkDecorator(new ChocolateDecorator(new Espresso()));
            Console.WriteLine($"El precio de {expressoWithMilkAndChocolate.GetDescription()} es {expressoWithMilkAndChocolate.GetCoast()}");

            Console.ReadLine();
        }
    }
}
