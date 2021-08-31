using System;

namespace Module10Task2
{
    public interface ICalculator
    {
        void GetSum(ILogger logger);
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
    class Calculator : ICalculator
    {
        public Calculator()
        {

        }
        public void GetSum(ILogger logger)
        {
            Console.WriteLine("Введите первое слагаемое:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе слагаемое:");
            int b = Convert.ToInt32(Console.ReadLine());

            logger.Event("Сумматор начинает свою суперсложную работу. Подождите 5 секунд...");
            System.Threading.Thread.Sleep(5000);
            logger.Event("Сумматор окончил свою работу. Вот результат:");
            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine("Чтобы сложить еще пару чисел, введите \"1\", для выхода нажмите любую клавишу.");
            if (Console.ReadLine() == "1")
                GetSum(logger);
            else
            {
                Console.WriteLine("До свидания, пользуйтесь этим тормознутым сумматором еще)");
                return;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            try
            {
                Calculator calculator = new Calculator();
                calculator.GetSum(logger);
            }
            catch (FormatException)
            {
                logger.Error("Введено значение неверного формата...");
                Program.Main(args);
            }
            catch (OverflowException)
            {
                logger.Error("Введено слишком маленькое/слишком большое число...");
                Program.Main(args);
            }
            catch (Exception)
            {
                Console.WriteLine("Произошла непредвиденная ошибка...");
            }

        }
    }
}
