using System;

namespace LabRob_1
{
    class Program
    {
        static int number;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Initialization();

            int[] numbers = Create_Number_Array(number, Number_Of_Digits(number));

            Arithmetic_Mean(numbers);
            Geometric_Mean(numbers);

            Factorial(number);

            Summ_Odd_Numbers(5, 10);
            Summ_Odd_Numbers(number);
           
            Summ_Even_Numbers_For(5, 10);
            Summ_Even_Numbers_For(number);
            Summ_Even_Numbers_While(number);
            Summ_Even_Numbers_DoWhile(number);
           

            Console.ReadKey();
        }

        static void Initialization() // ініціалізація вхідних даних
        {
            bool correctly = false;

            Console.Write("Введіть ціле число: ");

            while (!correctly)
            {
                string input = Console.ReadLine();
                correctly = int.TryParse(input, out number);
                if (number == 0) correctly = false;

                if (!correctly)
                {
                    Console.Write("Введено некоректне значення. Спробуйте ще раз: ");
                }
            }

            number = Math.Abs(number);
            Console.WriteLine($"Ви ввели {number} (абсолютне значення).\n ");
        }

        static void Show_Array(int[] nums) // вивід елементів масиву 
        {
            foreach(int i in nums)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(".\n");
        }

        static int Number_Of_Digits(int number) // кількість цифр в числі number (1)
        {
            int counter = 0;

            while (number > 0)
            {
                number /= 10;
                counter++;
            }

            Console.WriteLine($"Кількість цифр в числі {Program.number}: {counter}.");
            return counter;
        }

        static int[] Create_Number_Array(int number, int counter) // створення масиву на основі числа number (2)
        {
            int[] number_array = new int[counter];

            for (uint i = 0; i < number_array.Length; i++)
            {
                number_array[i] = number % 10;
                number /= 10;
            }
            Array.Reverse(number_array);

            Console.Write($"На основі числа {Program.number} створено масив: ");
            Show_Array(number_array);

            return number_array;
        }

        static double Arithmetic_Mean(int[] nums) // середнє арифметичне масиву (3)
        {
            int summ = 0;
            double answer = 0;

            for (uint i = 0; i < nums.Length; i++)
            {
                summ += nums[i];
            }

            answer = (double)summ / nums.Length;
            Console.WriteLine($"Середнє арифметичне значення масиву ≈ {answer: 0.000}.");

            return answer;
        }

        static double Geometric_Mean(int[] nums) // середнє геометричне масиву (4)
        {
            double prod = 1;
            double answer = 0;

            for (uint i = 0; i < nums.Length; i++)
            {
                prod *= nums[i];
            }

            answer = (double)Math.Pow(prod, 1.0 / nums.Length);
            Console.WriteLine($"Середнє геометричне значення масиву ≈ {answer: 0.000}.\n");

            return answer;
        }

        static ulong Factorial(int number) // факторіал числа number (5)
        {
            ulong answer = 1;

            if (number > 65)
            {
                Console.WriteLine("Значення аргументу не може бути більшим за 65. Виконання методу Factorial() припинено.\n");
                return 0;
            }
            for (uint i = 1; i <= number; i++)
            {
                unchecked
                {
                    answer *= i;
                }
            }

            Console.WriteLine($"Факторіал числа {Program.number} = {answer}.\n ");

            return answer;
        }

        static int Summ_Odd_Numbers(int number) //  сума непарних чисел від 1 до number (7)
        {
            int answer = 0;

            for (int i = 1; i <= number; i++)
            {
                if (i % 2 != 0)
                {
                    answer += i;
                }
            }

            Console.WriteLine($"Сума непарних чисел від 1 до {number}: {answer}.\n");
            return answer;
        }

        static int Summ_Even_Numbers_For(int number) //  сума парних чисел від 1 до number (for) (6)
        {
            int answer = 0;

            for (int i = 1; i <= number; i++)
            {
                if (i % 2 == 0)
                {
                    answer += i;
                }
            }

            Console.WriteLine($"Сума парних чисел від 1 до {number}: {answer}. Використано цикл for().");
            return answer;
        }

        static int Summ_Even_Numbers_While(int number) //  сума парних чисел від 1 до number (while) (6)
        {
            int answer = 0;
            int i = number;

            while (i != 0)
            {
                if (i % 2 == 0) answer += i;
                i--;
            }

            Console.WriteLine($"Сума парних чисел від 1 до {number}: {answer}. Використано цикл while().");
            return answer;
        }

        static int Summ_Even_Numbers_DoWhile(int number) //  сума парних чисел від 1 до N (do-while) (6)
        {
            int answer = 0;
            int i = number;

            do
            {
                if (i % 2 == 0) answer += i;
                i--;
            }
            while (i != 0);

            Console.WriteLine($"Сума парних чисел від 1 до {number}: {answer}. Використано цикл do-while().");
            return answer;
        }

        static int Summ_Odd_Numbers(int start, int finish) // сума непарних чисел, обмеженого діапазоном (8)
        {
            int answer = 0;

            for (int i = start; i <= finish; i++)
            {
                if (i % 2 != 0)
                {
                    answer += i;
                }
            }

            Console.WriteLine($"Сума непарних чисел від {start} до {finish}: {answer}.");
            return answer;
        }

        static int Summ_Even_Numbers_For(int start, int finish) // сума парних чисел, обмеженого діапазоном (8)
        {
            int answer = 0;

            for (int i = start; i <= finish; i++)
            {
                if (i % 2 == 0)
                {
                    answer += i;
                }
            }

            Console.WriteLine($"Сума парних чисел від {start} до {finish}: {answer}.");
            return answer;
        }
    }
}
