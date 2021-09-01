using System;

namespace Module10Task2
{
    public interface ICalculator
    {
        void GetResult(ILogger logger);
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
        public void GetResult(ILogger logger)
        {
            Console.WriteLine("Введите число:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Выберите операцию (введите нужное число):\nсложение - 1, вычитание - 2, умножение - 3,\nделение - 4, возведение в степень - 5, выход - любая другая клавиша");
            switch (Console.ReadLine())
            {
                case "1":
                    Addition(logger, a);
                    break;
                case "2":
                    Subtraction(logger, a);
                    break;
                case "3":
                    Multiplication(logger, a);
                    break;
                case "4":
                    Division(logger, a);
                    break;
                case "5":
                    Exponentiation(logger, a);
                    break;
                default:
                    return;
            }

        }
        #region Арифметические операции
        public void Addition(ILogger logger, double a)
        {
            Console.WriteLine("Введите слагаемое:");
            double b = Convert.ToDouble(Console.ReadLine());
            logger.Event("Калькулятор начинает свою суперсложную работу. Подождите 5 секунд...");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(a + b, 3);
            logger.Event("Сумматор окончил свою работу. Вот результат:");
            Console.WriteLine($"{a} + {b} = {c}");
        }
        public void Subtraction(ILogger logger, double a)
        {
            Console.WriteLine("Введите вычитаемое:");
            double b = Convert.ToDouble(Console.ReadLine());
            logger.Event("Калькулятор начинает свою суперсложную работу. Подождите 5 секунд...");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(a - b, 3);
            logger.Event("Калькулятор окончил свою работу. Вот результат:");
            Console.WriteLine($"{a} - {b} = {c}");
        }
        public void Multiplication(ILogger logger, double a)
        {
            Console.WriteLine("Введите множитель:");
            double b = Convert.ToDouble(Console.ReadLine());
            logger.Event("Калькулятор начинает свою суперсложную работу. Подождите 6 секунд...");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(a * b, 3);
            logger.Event("Калькулятор окончил свою работу. Вот результат:");
            Console.WriteLine($"{a} * {b} = {c}");
        }
        public void Division(ILogger logger, double a)
        {
            Console.WriteLine("Введите делитель:");
            double b = Convert.ToDouble(Console.ReadLine());
            if(b == 0.0)
                throw new DivideByZeroException();
            logger.Event("Калькулятор начинает свою суперсложную работу. Подождите 6 секунд...");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(a / b, 3);
            logger.Event("Калькулятор окончил свою работу. Вот результат:");
            Console.WriteLine($"{a} / {b} = {c}");
        }
        public void Exponentiation(ILogger logger, double a)
        {
            if (!(a > 0.0))
                throw new Exception("Возводить в степень можно только положительные числа...");
            Console.WriteLine("Введите показатель степени:");
            double b = Convert.ToDouble(Console.ReadLine());
            logger.Event("Калькулятор начинает свою суперсложную работу. Подождите 7 секунд...");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(Math.Pow(a, b), 3);
            logger.Event("Калькулятор окончил свою работу. Вот результат:");
            Console.WriteLine($"{a} ^ {b} = {c}");
        }
        #endregion

    }
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            //Calculator calculator = new Calculator(); !!!!!!! Если так сделать !!!!!!!
            try
            {
                Calculator calculator = new Calculator();
                calculator.GetResult(logger);
            }
            catch (FormatException)
            {
                logger.Error("Введено значение неверного формата...");
                Program.Main(args);
                //calculator.GetResult(logger); !!!!!!!!!! И так, то почему-то исключения перестают работать(
            }
            catch (OverflowException)
            {
                logger.Error("Введено слишком маленькое/слишком большое число...");
                Program.Main(args); // Как по-другому возвращаться после исключения к введению числа???
            }
            catch (DivideByZeroException)
            {
                logger.Error("На 0 делить нельзя...");
                Program.Main(args);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                Program.Main(args);
            }

        }
    }
}
