using System;

namespace Module10Tasks1_2
{
    public interface ISum
    {
        int GetSum(int a, int b);
    }
    class Calculator : ISum
    {
        public int GetSum(int a, int b)
        {
            return a + b;
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
            catch(FormatException)
            {
                Console.WriteLine("Введено значение неверного формата...");
                Program.Main(args);
            }
            catch(Exception)
            {
                Console.WriteLine("Произошла непредвиденная ошибка...");
            }

        }
    }
}
