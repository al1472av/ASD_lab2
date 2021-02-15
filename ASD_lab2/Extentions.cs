using System;

namespace ASD_lab2
{
    public static class Extentions
    {
        public static void SafeRunning(Action action, string errorMessage = "Error")
        {
            do
            {
                try
                {
                    action?.Invoke();
                    break;
                }
                catch
                {
                    Console.WriteLine(errorMessage);
                }
            } while (true);
        }

        public static void Swap<T>(ref T first, ref T second)
        {
            T temp;

            temp = first;
            first = second;
            second = temp;
        }
    }
    
}