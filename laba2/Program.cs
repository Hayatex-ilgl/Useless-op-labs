using System;
using System.Diagnostics;
namespace laba2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool exitflag = true;

            while (exitflag)
            {

                Console.WriteLine("Выберите опцию:\n 1.игра угадай число\n 2.Об авторе\n 3.Сортировка массива\n 4.Четыре в ряд\n 5.выходж");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        calcNum();
                        break;
                    case "2":
                        Info();
                        break;
                    case "3":
                        Console.WriteLine("Введите колличество элементов в массиве");
                        ArrSort();
                        break;
                    case "4":
                        Game();
                        break;
                    case "5":
                        exitflag = Exit();
                        break;
                    default:
                        Console.WriteLine("нет такой функции, попробуйте снова:");
                        break;
                }
            }
        }

        //static void calcNum()
        //{
        //    double b = inputcheck("Введите значение b (b>0): ", "неверный ввод,введите значение b снова: ", true, false, 0);
        //    double alpha = inputcheck("Введите значение a в градусах (a не может быть равным 90 и -90): ", "неверный ввод,введите значение a снова: ", false, true, 0);
        //    Console.WriteLine("     cos^7(p) + √(ln(b^4))");
        //    Console.WriteLine("f = ————————————————————-- =");
        //    Console.WriteLine("       sin^2(p/2 + a)");
        //    double programResult = CalculateFunction(b, alpha);
        //    Guessnum(programResult);
        //}
        static void Info()
        {
            Console.WriteLine("Студент:Асатрян Карен Араевич,Группа 6105");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        static void ArrSort()
        {
            int n = Inputlen();
            int[] array = CreateArray(n);

            Console.Write("изначальный массив: ");
            PrintArray(array);
            Console.WriteLine(" \n");

            int[] arrayForBubbleSort = CopyArray(array);
            int[] arrayForShellSort = CopyArray(array);

            Stopwatch BubbleTime = new Stopwatch();
            BubbleTime.Start();
            BubbleSort(arrayForBubbleSort);
            BubbleTime.Stop();

            Console.Write("Сортировка пузырьком: ");
            PrintArray(arrayForBubbleSort);
            Console.WriteLine();
            Console.WriteLine($"Время выполнения: {BubbleTime.Elapsed}");
            Console.WriteLine();

            Stopwatch ShellTime = new Stopwatch();
            ShellTime.Start();
            ShellSort(arrayForShellSort);
            ShellTime.Stop();

            Console.Write("Метод Шелла: ");
            PrintArray(arrayForShellSort);
            Console.WriteLine("");
            Console.WriteLine($"Время выполнения: {ShellTime.Elapsed}");
            Console.WriteLine("");

            Console.Write("Наиболее быстрый метод: ");
            if (BubbleTime.Elapsed > ShellTime.Elapsed)
            {
                Console.WriteLine("шелла");
                Console.WriteLine(" ");
                Console.WriteLine($"Разница в секундах:{BubbleTime.Elapsed - ShellTime.Elapsed}");
            }
            else
            {
                Console.WriteLine("пузырьковый");
                Console.WriteLine(" ");
                Console.WriteLine($"Разница в с:{-BubbleTime.Elapsed + ShellTime.Elapsed}");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        static bool Exit()
        {
            while (true)
            {
                Console.WriteLine("Вы точно хотие выйти y/n");
                string exitanswer = Console.ReadLine();
                if (exitanswer == "y")
                {
                    return false;
                }
                else if (exitanswer == "n")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильное значение, попробуйте снова.");
                }
            }
        }
        //static double CalculateFunction(double b, double alpha)
        //{
        //    double alphaRad = alpha * Math.PI / 180;
        //    double numerator = Math.Pow(Math.Cos(Math.PI), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4)));
        //    double denominator = Math.Sin(Math.Pow((Math.PI / 2 + alphaRad), 2));
        //    return Math.Round((numerator / denominator), 2);
        //}
        //static void Guessnum(double programResult)
        //{
        //    double userResult = 0;
        //    int attemp = 0;
        //    bool trueflag = false;

        //    Console.Write("Введите ваш результат: ");

        //    while (trueflag == false && attemp < 100)
        //    {
        //        userResult = inputcheck("", "неверный ввод,введите ответ снова: ", false, false, 0);
        //        userResult = Math.Round(userResult, 2);
        //        if (userResult != programResult)
        //        {
        //            Console.Clear();
        //            attemp++;
        //            Console.WriteLine($"Вы не угадали,попытка№:{attemp}\n осталось попыток {100 - attemp} ");
        //            Console.Write("Введите ваш результат снова: ");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Вы угадали");
        //            trueflag = true;
        //        }
        //    }

        //    if (!trueflag)
        //    {
        //        Console.WriteLine("Игра окончена");
        //    }

        //    Console.WriteLine("Нажмите любую клавишу для продолжения...");
        //    Console.ReadKey();
        //}
        static int Inputlen()
        {
            int n;
            bool wrongans = false;

            while (true)
            {
                if (wrongans == true) { Console.WriteLine("Введите длину массива до 10:"); }
                n = (int)inputcheck("", "", false, false, 0);
                if (n <= 10 && n > 0)
                {
                    return n;
                }
                else
                {
                    if (n > 10 || n <= 0)
                    {
                        return n;
                    }
                    else
                    {
                        //Console.Clear();
                        Console.Write("недопустимое значение.");
                    }
                    wrongans = true;
                }
            }
        }
        static double inputcheck(string prompt, string error, bool checkPositive, bool checkNot90, double defaultValue)
        {
            double number = 0;
            bool wrongparse = true;

            while (wrongparse)
            {
                if (!string.IsNullOrEmpty(prompt))
                {
                    Console.Write(prompt);
                }

                if (double.TryParse(Console.ReadLine(), out number))
                {
                    if (checkPositive && number <= 0)
                    {
                        //  Console.Clear();
                        Console.Write(error);
                        Console.WriteLine("Недопустимое значение");
                    }
                    else if (checkNot90 && (number == 90 || number == -90))
                    {
                        // Console.Clear();
                        Console.WriteLine("Недопустимое значение");
                        Console.Write(error);
                    }
                    else
                    {
                        wrongparse = false;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Недопустимое значение");
                    Console.Write(error);
                }
            }

            Console.Clear();
            return number;
        }
        static int[] CreateArray(int n1)
        {
            int[] array = new int[n1];
            Random rand = new Random();
            for (int i = 0; i < n1; i++) { array[i] = rand.Next(); }
            return array;
        }
        static int[] CopyArray(int[] sourceArray)
        {
            int[] copy = new int[sourceArray.Length];
            for (int i = 0; i < sourceArray.Length; i++)
            { copy[i] = sourceArray[i]; }
            return copy;
        }
        static void BubbleSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int k = 0; k < array.Length - i; k++)
                {
                    if (array[k] > array[k + 1])
                    {
                        int temp = array[k];
                        array[k] = array[k + 1];
                        array[k + 1] = temp;
                    }
                }
            }
        }
        static void ShellSort(int[] array)
        {
            int dist = array.Length / 2;

            while (dist > 0)
            {
                for (int i = dist; i < array.Length; i++)
                {
                    int k = i;
                    int current = array[k];

                    while (k >= dist && array[k - dist] > current)
                    {
                        array[k] = array[k - dist];
                        k = k - dist;
                    }
                    array[k] = current;
                }

                dist = dist / 2;
            }
        }
        static void PrintArray(int[] array)
        {
            if (array.Length > 10)

            { Console.Write("Первые 10 элементов:"); for (int i = 0; i <= 10; i++) { Console.Write(array[9] + " "); } }
            else { for (int i = 0; i <= array.Length - 1; i++) { Console.Write(array[array.Length - 1] + " "); } }
        }
        static void Game()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в игру '4 в ряд'!");

            Console.Write("Введите имя первого игрока: ");
            string player1 = Console.ReadLine();
            Console.Write("Введите имя второго игрока: ");
            string player2 = Console.ReadLine();

            char[,] gamefield = CreateGameField();
            char currentPlayerSymbol = 'X';
            string currentPlayerName = player1;
            bool gameOver = false;
            int movesCount = 0;

            while (!gameOver && movesCount < 42)
            {
                PrintGameField(gamefield);
                Console.WriteLine($"\nХод игрока: {currentPlayerName} ({currentPlayerSymbol})");

                int column = GetPlayerMove(gamefield);
                int row = DropPiece(gamefield, column, currentPlayerSymbol);

                if (row != -1)
                {
                    movesCount++;

                    if (CheckWin(gamefield, row, column, currentPlayerSymbol))
                    {
                        PrintGameField(gamefield);
                        Console.WriteLine($"\nПоздравляем! {currentPlayerName} победил!");
                        gameOver = true;
                    }
                    else if (movesCount == 42)
                    {
                        PrintGameField(gamefield);
                        Console.WriteLine("\nНичья! Все ячейки заполнены.");
                        gameOver = true;
                    }
                    else
                    {
                        if (currentPlayerSymbol == 'X')
                        {
                            currentPlayerSymbol = 'O';
                            currentPlayerName = player2;
                        }
                        else
                        {
                            currentPlayerSymbol = 'X';
                            currentPlayerName = player1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Этот столбец полностью заполнен! Выберите другой.");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        static int GetPlayerMove(char[,] gamefield)
        {
            int column = 1;
            bool validMove = false;

            while (!validMove)
            {
                Console.Write("Выберите столбец (1-7): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out column) && column >= 1 && column <= 7)
                {
                    column--;

                    if (gamefield[0, column] == ' ')
                    {
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("Этот столбец полностью заполнен! Выберите другой.");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Введите число от 1 до 7.");
                }
            }

            return column;
        }

        static int DropPiece(char[,] gamefield, int column, char symbol)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (gamefield[row, column] == ' ')
                {
                    gamefield[row, column] = symbol;
                    return row;
                }
            }
            return 1;
        }

        static bool CheckWin(char[,] gamefield, int row, int column, char symbol)
        {
            int count = 0;
            for (int c = 0; c < 7; c++)
            {
                count = (gamefield[row, c] == symbol) ? count + 1 : 0;
                if (count >= 4) return true;
            }

            count = 0;
            for (int r = 0; r < 6; r++)
            {
                count = (gamefield[r, column] == symbol) ? count + 1 : 0;
                if (count >= 4) return true;
            }

            count = 0;
            int startRow = row - Math.Min(row, column);
            int startCol = column - Math.Min(row, column);
            for (int r = startRow, c = startCol; r < 6 && c < 7; r++, c++)
            {
                count = (gamefield[r, c] == symbol) ? count + 1 : 0;
                if (count >= 4) return true;
            }

            count = 0;
            startRow = row - Math.Min(row, 6 - column);
            startCol = column + Math.Min(row, 6 - column);
            for (int r = startRow, c = startCol; r < 6 && c >= 0; r++, c--)
            {
                count = (gamefield[r, c] == symbol) ? count + 1 : 0;
                if (count >= 4) return true;
            }

            return false;
        }
        static char[,] CreateGameField()
        {
            char[,] gamefield = new char[6, 7];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    gamefield[i, j] = ' ';
                }
            }
            return gamefield;
        }

        static void PrintGameField(char[,] gamefieldc)
        {
            Console.Clear();
            Console.Write(" ");
            for (int i = 1; i <= 7; i++)
            {
                Console.Write($" {i}  ");
            }
            Console.WriteLine();

            Console.WriteLine("┌───┬───┬───┬───┬───┬───┬───┐");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("│");
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($" {gamefieldc[i, j]} │");
                }
                Console.WriteLine();
                if (i < 5)
                {
                    Console.WriteLine("├───┼───┼───┼───┼───┼───┼───┤");
                }
            }
            Console.WriteLine("└───┴───┴───┴───┴───┴───┴───┘");
        }
        public class guessnumber
        {
            static void CalcNum()
            {
                double b = inputcheck("Введите значение b (b>0): ", "неверный ввод,введите значение b снова: ", true, false, 0);
                double alpha = inputcheck("Введите значение a в градусах (a не может быть равным 90 и -90): ", "неверный ввод,введите значение a снова: ", false, true, 0);
                Console.WriteLine("     cos^7(p) + √(ln(b^4))");
                Console.WriteLine("f = ————————————————————-- =");
                Console.WriteLine("       sin^2(p/2 + a)");
                double programResult = CalculateFunction(b, alpha);
                Guessnum(programResult);
            }
            static double CalculateFunction(double b, double alpha)
            {
                double alphaRad = alpha * Math.PI / 180;
                double numerator = Math.Pow(Math.Cos(Math.PI), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4)));
                double denominator = Math.Sin(Math.Pow((Math.PI / 2 + alphaRad), 2));
                return Math.Round((numerator / denominator), 2);
            }
            static void Guessnum(double programResult)
            {
                double userResult = 0;
                int attemp = 0;
                bool trueflag = false;

                Console.Write("Введите ваш результат: ");

                while (trueflag == false && attemp < 100)
                {
                    userResult = inputcheck("", "неверный ввод,введите ответ снова: ", false, false, 0);
                    userResult = Math.Round(userResult, 2);
                    if (userResult != programResult)
                    {
                        Console.Clear();
                        attemp++;
                        Console.WriteLine($"Вы не угадали,попытка№:{attemp}\n осталось попыток {100 - attemp} ");
                        Console.Write("Введите ваш результат снова: ");
                    }
                    else
                    {
                        Console.WriteLine("Вы угадали");
                        trueflag = true;
                    }
                }

                if (!trueflag)
                {
                    Console.WriteLine("Игра окончена");
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}