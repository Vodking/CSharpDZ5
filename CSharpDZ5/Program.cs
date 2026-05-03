using System.Data;

namespace CSharpDZ5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int grade;

            //double[,] arr1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //Matrix matrix1 = new Matrix(arr1, 3, 3);
            //double[,] arr2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //Matrix matrix2 = new Matrix(arr2, 3, 3);

            //Matrix matrix3 = matrix1 + matrix2;


            //matrix1.Print();
            //Console.WriteLine();
            //matrix2.Print();
            //Console.WriteLine();
            //matrix3.Print();
            //Console.Write("Введите разряд матрицы");
            //grade = Convert.ToInt32(Console.ReadLine());

            int userInput;

            while (true)
            {
                Console.WriteLine("Урок 5\n");
                do
                {
                    Console.Write("Введите номер задания: 1 - 1 задание 1 вариант 2 - 1 задание 2 вариант, 3 - матрицы, 4 - выйти: ");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput < 0 || userInput > 4)
                    {
                        Console.WriteLine("Ввод вне диапазона!");
                    }
                    else
                    {
                        break;
                    }

                    

                } while (true);

                if(userInput == 4)
                {
                    break;
                }
                else if (userInput == 1)
                {
                    TaskGiver.Task1();
                }
                else if (userInput == 2)
                {
                    TaskGiver.Task2();
                }
                else if(userInput == 3)
                {
                    TaskGiver.Task3();
                }

            }
        }
    }
}
