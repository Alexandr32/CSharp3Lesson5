using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp3Lesson5
{
    /// <summary>
    /// Класс для передачи введенного числа
    /// </summary>
    class NumberEntered
    {
        public int Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                NumberEntered numberEntered = new NumberEntered
                {
                    Number = number
                };

                Thread thread = new Thread(new ParameterizedThreadStart(Factorial));
                thread.Start(numberEntered);

            }
            else
            {
                Console.WriteLine("Введено не число");
            }

            Console.ReadKey();
        }

        static void Factorial(object objNumb)
        {
            
            if (objNumb is NumberEntered numb)
            {
                int n = numb.Number;
                int factorial = 1;   // значение факториала

                for (int i = 2; i <= n; i++) // цикл начинаем с 2, т.к. нет смысла начинать с 1
                {
                    factorial *= i;
                }
                Console.WriteLine(factorial);
            }
        }
    }
}
