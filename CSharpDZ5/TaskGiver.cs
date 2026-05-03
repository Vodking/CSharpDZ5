using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDZ5
{
    public static class TaskGiver
    {
        public static void Task1()
        {
            string name;
            double average, achievement;
            Console.WriteLine("Создание обьекта абитуриента");
            Console.Write("Введите ФИО абитуриента: ");
            name = Console.ReadLine();

            do
            {
                Console.Write("Введите средний бал аттестата абитуриента(0 - 5): ");
                average = Convert.ToDouble(Console.ReadLine());
                if (average < 0 || average > 5)
                {
                    Console.WriteLine("Ввод вне диапазона!");
                }
                else
                {
                    break;
                }
            } while (true);

            do
            {
                Console.Write("Введите баллы за личные достижения(0 - 5): ");
                achievement = Convert.ToDouble(Console.ReadLine());
                if (achievement < 0 || achievement > 5)
                {
                    Console.WriteLine("Ввод вне диапазона!");

                }
                else
                {
                    break;
                }
            } while (true);

            var student = new Abiturient(name, average, achievement);

            Console.WriteLine("Проверка среднего балла нового студента: ");
            if (Checker.Prohod(student))
            {
                Console.WriteLine("Студент прошёл проверку");
            }
            else
            {
                Console.WriteLine("Студент не прошёл проверку");
            }
        }

        public static void Task2()
        {
            string name;
            double sum, percent;
            Console.WriteLine("Создание объекта вклада");

            Console.Write("Введите ФИО владельца вклада: ");
            name = Console.ReadLine();

            do
            {
                Console.Write("Введите сумму вклада: ");
                sum = Convert.ToDouble(Console.ReadLine());
                if(sum < 0)
                {
                    Console.WriteLine("Вклад не может быть отрицательным!");
                }
                else
                {
                    break;
                }
            } while (true);

            do
            {
                Console.Write("Введите процентную ставку: ");
                percent = Convert.ToDouble(Console.ReadLine());
                if (percent < 0 || percent > 100)
                {
                    Console.WriteLine("Процент должен быть от 0 до 100");
                }
                else
                {
                    break;
                }
            }while(true);

            var invest = new Investement(name, sum);
            Investement.Growth = 1 + percent / 100;

            while(true)
            {
                
                do
                {
                    Console.Write("1 - применить ++, 2 - узнать процентную ставку, 3 - перейти к кредитам: ");
                    sum = Convert.ToDouble(Console.ReadLine());
                    if( sum < 0 || sum > 3)
                    {
                        Console.WriteLine("Ввод вне диапазона!");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                if(sum == 1)
                {
                    Console.WriteLine($"Вклад до ++: {invest.InvestmentSum}");
                    invest++;
                    Console.WriteLine($"Вклад после ++: {invest.InvestmentSum}");

                }
                else if(sum == 2)
                {
                    Console.WriteLine($"Процентная ставка: {Investement.Growth}");
                }
                else if (sum == 3)
                {
                    break;
                }
            }

            Console.WriteLine("Создание объекта кредита");

            Console.Write("Введите ФИО владельца кредита: ");
            name = Console.ReadLine();

            do
            {
                Console.Write("Введите сумму кредита: ");
                sum = Convert.ToDouble(Console.ReadLine());
                if (sum < 0)
                {
                    Console.WriteLine("Кредит не может быть отрицательным!");
                }
                else
                {
                    break;
                }
            } while (true);

            do
            {
                Console.Write("Введите процентную ставку: ");
                percent = Convert.ToDouble(Console.ReadLine());
                if (percent < 0 || percent > 100)
                {
                    Console.WriteLine("Процент должен быть от 0 до 100");
                }
                else
                {
                    break;
                }
            } while (true);

            var loan = new Loan(name, sum);
            Loan.LoanPercentage = -(1 + percent / 100);

            while (true)
            {

                do
                {
                    Console.Write("1 - применить --, 2 - узнать процентную ставку, 3 - выход в меню: ");
                    sum = Convert.ToDouble(Console.ReadLine());
                    if (sum < 0 || sum > 3)
                    {
                        Console.WriteLine("Ввод вне диапазона!");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                if (sum == 1)
                {
                    Console.WriteLine($"Кредит до --: {loan.LoanSum}");
                    loan--;
                    Console.WriteLine($"Кредит после --: {loan.LoanSum}");

                }
                else if (sum == 2)
                {
                    Console.WriteLine($"Процентная ставка: {Investement.Growth}");
                }
                else if (sum == 3)
                {
                    break;
                }
            }

        }

        public static void Task3()
        {
            int userInput, userInput2;
            double doubleInput;
            Random rnd = new Random();
            double[,] arr1, arr2;
            Matrix mtx1, mtx2;

            while (true)
            {
                Console.WriteLine("Матрицы");
                Console.WriteLine("Если вывод: -1 - Некорректная операция(невозможна)");


                do
                {
                    Console.Write("1 - Создать свои матрицы, 2 - Рандомно сгенерированные матрицы, 3 - выход: ");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if(userInput < 0 || userInput > 3)
                    {
                        Console.WriteLine("Ввод вне диапазона!");
                    }
                    else
                    {
                        break;
                    }
                } while (true);
                if(userInput == 1)
                {
                   do
                    {
                        Console.Write("Введите первый размер первой матрицы: ");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        if(userInput <= 0)
                        {
                            Console.WriteLine("Размер не может быть отрицательным!");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                    do
                    {
                        Console.Write("Введите второй размер первой матрицы: ");
                        userInput2 = Convert.ToInt32(Console.ReadLine());
                        if (userInput <= 0)
                        {
                            Console.WriteLine("Размер не может быть отрицательным!");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);

                    arr1 = new double[userInput, userInput2];

                    for(int i = 0; i < userInput; i++)
                    {
                        for(int j = 0; j < userInput2; j++)
                        {
                            Console.Write($"Введите элемент {i} {j}");
                            arr1[i,j] = Convert.ToDouble(Console.ReadLine());
                        }
                    }
                    mtx1 = new Matrix(arr1, userInput, userInput2);

                    do
                    {
                        Console.Write("Введите первый размер второй матрицы: ");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        if (userInput <= 0)
                        {
                            Console.WriteLine("Размер не может быть отрицательным!");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                    do
                    {
                        Console.Write("Введите второй размер второй матрицы: ");
                        userInput2 = Convert.ToInt32(Console.ReadLine());
                        if (userInput <= 0)
                        {
                            Console.WriteLine("Размер не может быть отрицательным!");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);

                    arr2 = new double[userInput, userInput2];

                    for (int i = 0; i < userInput; i++)
                    {
                        for (int j = 0; j < userInput2; j++)
                        {
                            Console.Write($"Введите элемент {i} {j}");
                            arr2[i, j] = Convert.ToDouble(Console.ReadLine());
                        }
                    }

                    mtx2 = new Matrix(arr2, userInput, userInput2);

                }
                else if(userInput == 2)
                {
                    do
                    {
                        Console.Write("Введите первый размер первой матрицы: ");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        if (userInput <= 0)
                        {
                            Console.WriteLine("Размер не может быть отрицательным!");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);

                    do
                    {
                        Console.Write("Введите второй размер первой матрицы: ");
                        userInput2 = Convert.ToInt32(Console.ReadLine());
                        if (userInput <= 0)
                        {
                            Console.WriteLine("Размер не может быть отрицательным!");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);

                    arr1 = new double[userInput, userInput2];

                    for(int i = 0;i < userInput;i++)
                    {
                        for(int j = 0;j < userInput2;j++)
                        {
                            arr1[i, j] = rnd.Next(-10, 10);
                        }
                    }

                    mtx1 = new Matrix(arr1, userInput, userInput2);

                    do
                    {
                        Console.Write("Введите первый размер второй матрицы: ");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        if (userInput <= 0)
                        {
                            Console.WriteLine("Размер не может быть отрицательным!");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);

                    do
                    {
                        Console.Write("Введите второй размер второй матрицы: ");
                        userInput2 = Convert.ToInt32(Console.ReadLine());
                        if (userInput <= 0)
                        {
                            Console.WriteLine("Размер не может быть отрицательным!");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);

                    arr2 = new double[userInput, userInput2];

                    for (int i = 0; i < userInput; i++)
                    {
                        for (int j = 0; j < userInput2; j++)
                        {
                            arr2[i, j] = rnd.Next(-10, 10);
                        }
                    }

                    mtx2 = new Matrix(arr2, userInput, userInput2);
                }
                else if(userInput == 3)
                {
                    break;
                }
                else
                {
                    double[,] temp = new double[1, 1] { { -1 } };
                    mtx1 = new Matrix(temp, 1, 1);
                    mtx2 = new Matrix(temp, 1, 1);
                }

                Console.WriteLine("Матрица 1:");
                mtx1.Print();
                Console.WriteLine("Матрица 2:");
                mtx2.Print();
                Matrix mtx3;

                Console.WriteLine("умножение матриц: ");
                mtx3 = mtx1 * mtx2;
                mtx3.Print();
                Console.WriteLine("\nЛюбая кнопка чтобы продолжить...");
                Console.ReadKey();

                Console.WriteLine("умножение матрицы на число: ");
                Console.Write("Введите число: ");
                doubleInput = Convert.ToDouble(Console.ReadLine());
                mtx3 = mtx1 * doubleInput;
                mtx3.Print();
                Console.WriteLine("\nЛюбая кнопка чтобы продолжить...");
                Console.ReadKey();

                Console.WriteLine("Сложение матриц: ");
                mtx3 = mtx1 + mtx2;
                mtx3.Print();
                Console.WriteLine("\nЛюбая кнопка чтобы продолжить...");
                Console.ReadKey();

                Console.WriteLine("Сложение матрицы и числа: ");
                Console.Write("Введите число: ");
                doubleInput = Convert.ToDouble(Console.ReadLine());
                mtx3 = mtx1 + doubleInput;
                mtx3.Print();
                Console.WriteLine("\nЛюбая кнопка чтобы продолжить...");
                Console.ReadKey();

                Console.WriteLine("Вычитание матриц: ");
                mtx3 = mtx1 - mtx2;
                mtx3.Print();
                Console.WriteLine("\nЛюбая кнопка чтобы продолжить...");
                Console.ReadKey();

                Console.WriteLine("вычитание матрицы и числа: ");
                Console.Write("Введите число: ");
                doubleInput = Convert.ToDouble(Console.ReadLine());
                mtx3 = mtx1 - doubleInput;
                mtx3.Print();
                Console.WriteLine("\nЛюбая кнопка чтобы продолжить...");
                Console.ReadKey();

                Console.WriteLine("сравнение матриц(по сумме всех элементов): ");
                if(mtx1 == mtx2)
                {
                    Console.WriteLine("Матрицы равны");
                }
                else if(mtx1 > mtx2)
                {
                    Console.WriteLine("Первая матрица больше");
                }
                else
                {
                    Console.WriteLine("Первая матрица меньше");
                }
                Console.WriteLine("\nЛюбая кнопка чтобы продолжить...");
                Console.ReadKey();


            }
        }
    }
}
