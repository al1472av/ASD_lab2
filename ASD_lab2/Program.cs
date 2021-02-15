using System;
using System.Collections.Generic;
using SafeReader;

namespace ASD_lab2
{
    internal class Program
    {
        private static ITaskSolver[] tasks = {new Task0(), new Task1(), new Task2(), new Task3(), new Task4()};

        public static void Main(string[] args)
        {
            while (true)
                Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1\n2\n3\n4\nExit 0\n");

            Extentions.SafeRunning(Menu, $"Index out of bound, should be between 0 and {tasks.Length}");

            void Menu()
            { 
                int task = ConsoleReader.ReadInt(0, tasks.Length, "Out of range");
                tasks[task].SolveTask();
            }
        }
    }

    interface ITaskSolver
    {
        void SolveTask();
    }

    public class Task0 : ITaskSolver
    {
        public void SolveTask()
        {
            Environment.Exit(0);
        }
    }

    public class Task1 : ITaskSolver
    {
        public void SolveTask()
        {
            Random random = new Random();

            int negativeSum = 0, min = int.MaxValue, max = int.MinValue;
            int startPos = -1;
            int endPos = -1;
            int multiplyResult = 1;
            Console.WriteLine("Array size:");

            int size = ConsoleReader.ReadInt();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-100, 101);
                if (array[i] < 0)
                    negativeSum += array[i];

                if (array[i] < min)
                {
                    min = array[i];
                    startPos = i;
                }

                if (array[i] > max)
                {
                    max = array[i];
                    endPos = i;
                }

                Console.WriteLine(array[i]);
            }

            if (startPos > endPos)
                Extentions.Swap(ref startPos, ref endPos);

            for (int i = startPos + 1; i < endPos; i++)
                multiplyResult *= array[i];

            Console.WriteLine($"Negtive sum = {negativeSum}\nMultiply result = {multiplyResult}");
            Console.ReadKey();
        }
    }

    public class Task2 : ITaskSolver
    {
        private const int MAX = 5;

        public void SolveTask()
        {
            Console.WriteLine("Array size:");
            int[] array = new int[ConsoleReader.ReadInt()];
            List<int> streaks = new List<int>(new int[MAX]);

            for (int i = 0; i < streaks.Count; i++)
                streaks[i] = 1;

            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, MAX);
                Console.Write(array[i] + " ");
                if (i == 0) continue;

                if (array[i] == array[i - 1])
                    streaks[array[i]]++;
                else if (streaks[array[i - 1]] < 3)
                    streaks[array[i - 1]] = 1;
            }


            Console.WriteLine("\nThere were streaks of:");
            for (int i = 0; i < streaks.Count; i++)
                if (streaks[i] >= 3)
                    Console.WriteLine(i + " ");

            Console.ReadKey();
        }
    }

    public class Task3 : ITaskSolver
    {
        public void SolveTask()
        {
            Random random = new Random();

            Console.WriteLine("Enter i");
            int row = ConsoleReader.ReadInt();
            Console.WriteLine("Enter j");
            int min = 0, max = 10;
            int column = ConsoleReader.ReadInt();
            int[,] matrix = new int[row, column];
            int zeroLineCount = 0;
            int[] count = new int[max];

            for (int i = 0; i < row; i++)
            {
                bool containsZero = false;
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = random.Next(min, max);
                    Console.Write(matrix[i, j] + " ");
                    count[matrix[i, j]]++;
                    containsZero = matrix[i, j] == 0;
                }

                Console.Write("\n");

                if (!containsZero)
                    zeroLineCount++;
            }

            int maxIndex = 0;
            int tempMax = int.MinValue;
            for (int i = 0; i < max; i++)
            {
                if (count[i] > tempMax)
                {
                    tempMax = count[i];
                    maxIndex = i;
                }
            }

            Console.WriteLine(
                $"Lines count that does not contain zero {zeroLineCount}\nMost frequent number is {maxIndex}, {count[maxIndex]} times");
            Console.ReadKey();
        }
    }

    public class Task4 : ITaskSolver
    {
        public void SolveTask()
        {
            Console.WriteLine("Enter size");
            int size = ConsoleReader.ReadInt();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write((i <= j || i == size - j - 1 ? 1 : 0) + " ");

                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}