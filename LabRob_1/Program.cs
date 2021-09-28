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

            Factorial_For(number);
            Factorial_While(number);
            Factorial_Do_While(number);

            Summ_Odd_Numbers(numbers);
            Summ_Odd_Numbers(1, 3, numbers);
            Summ_Even_Numbers(numbers);
            Summ_Even_Numbers(1, 3, numbers);

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

        static int[] Create_Number_Array(int number, int counter) // створення масиву, на основі числа number (2)
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

        static ulong Factorial_For(int number) // факторіал числа number через for() (5)
        {
            ulong answer = 1;

            if (number > 65)
            {
                Console.WriteLine("Значення аргументу не може бути більшим за 65. Виконання методу Factorial_For() припинено. ");
                return 0;
            }
            for (uint i = 1; i <= number; i++)
            {
                unchecked
                {
                    answer *= i;
                }
            }

            Console.WriteLine($"Факторіал числа {Program.number} = {answer}. Використано метод Factorial_For(). ");

            return answer;
        }

        static ulong Factorial_While(int number) // факторіал числа number через while() (5)
        {
            ulong answer = 1;

            if (number > 65)
            {
                Console.WriteLine("Значення аргументу не може бути більшим за 65. Виконання методу Factorial_While() припинено. ");
                return 0;
            }

            while (number != 0)
            {
                unchecked
                {
                    answer *= (ulong)number--;
                }
            }
            Console.WriteLine($"Факторіал числа {Program.number} = {answer}. Використано метод Factorial_While(). ");

            return answer;
        }

        static ulong Factorial_Do_While(int number) // факторіал числа number через do{} while() (5)
        {
            ulong answer = 1;

            if (number > 65)
            {
                Console.WriteLine("Значення аргументу не може бути більшим за 65. Виконання методу Factorial_DoWhile() припинено.\n ");
                return 0;
            }

            do
            {
                unchecked
                {
                    answer *= (ulong)number--;
                }
            }
            while (number != 0);

            Console.WriteLine($"Факторіал числа {Program.number} = {answer}. Використано метод Factorial_DoWhile(). \n");

            return answer;
        }

        static int Summ_Odd_Numbers(int[] nums) //  сума непарних елементів ВСЬОГО масиву (7)
        {
            int answer = 0;

            for (uint i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    answer += nums[i];
                }
            }

            Console.WriteLine($"Сума непарних цифр масиву: {answer}.");
            return answer;
        }

        static int Summ_Even_Numbers(int[] nums) // сума парних елементів ВСЬОГО масиву (6)
        {
            int answer = 0;

            for (uint i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    answer += nums[i];
                }
            }

            Console.WriteLine($"Сума парних цифр масиву: {answer}.");
            return answer;
        }

        static int Summ_Odd_Numbers(Index start, Index finish, int[] nums) //  сума непарних елементів масиву, обмеженого діапазоном (8)
        {
            if (start.Value >= 0 && finish.Value < nums.Length)
            {
                int answer = 0;

                for (uint i = 0; i < nums.Length; i++)
                {
                    if (i < start.Value || i >= finish.Value) continue;

                    if (nums[i] % 2 != 0)
                    {
                        answer += nums[i];
                    }
                }

                Console.WriteLine($"Сума непарних цифр масиву (з діапазону [{start}..{finish}]): {answer}.\n");
                return answer;
            }
            else
            {
                Console.WriteLine("Методу передані некоректне значення діапазону. Виконання методу припинено.");
                return 0;
            }
        }

        static int Summ_Even_Numbers(Index start, Index finish, int[] nums) //  сума парних елементів масиву, обмеженого діапазоном (8)
        {
            if (start.Value >= 0 && finish.Value < nums.Length)
            {
                int answer = 0;

                for (uint i = 0; i < nums.Length; i++)
                {
                    if (i < start.Value || i >= finish.Value) continue;

                    if (nums[i] % 2 == 0)
                    {
                        answer += nums[i];
                    }
                }

                Console.WriteLine($"Сума парних цифр масиву (з діапазону [{start}..{finish}]): {answer}.");
                return answer;
            }
            else
            {
                Console.WriteLine("Методу передані некоректне значення діапазону. Виконання методу припинено.");
                return 0;
            }
        }
    }
}