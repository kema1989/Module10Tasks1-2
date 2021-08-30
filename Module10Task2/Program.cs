using System;

namespace Module10Task2
{
    public interface ICalculator
    {
        void GetSum(int a, int b);
    }
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
    class Sum : ICalculator
    {
        ILogger Logger { get; }
        public Sum(ILogger logger)
        {

        }
        public void GetSum(int a, int b)
        {
            Console.WriteLine("Введите первое слагаемое:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе слагаемое:");
            b = Convert.ToInt32(Console.ReadLine());

            Logger.Event("Сумматор начинает свою суперсложную работу...");
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Calculator calculator = new Calculator();
                Console.WriteLine("Введите первое слагаемое");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите второе слагаемое");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"{a} + {b} = " + calculator.GetSum(a, b));
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено значение неверного формата...");
                Program.Main(args);
            }
            catch (Exception)
            {
                Console.WriteLine("Произошла непредвиденная ошибка...");
            }

        }
    }
}
