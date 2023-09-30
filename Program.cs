using System;
using System.Data;
using System.Net.Http.Headers;
using System.Security.AccessControl;

public class Program
{
    const int Max_Score = 15;
    static int returnScore = Max_Score;

    static int answer = 0;
    static int index = 0;

    static List<DataRow> randomRows = GenerateRandomRows.Generate();

    public static void Main(string[] args)
    {
        AddQuestion();
    }

    static void AddQuestion()
    {
        foreach (DataRow row in randomRows)
        {
            if (index != 0)
                Console.WriteLine("\n");

            Console.Write("{0}) ", (index + 1));
            Console.Write(row[1].ToString());
            Console.WriteLine("\n");
            Console.WriteLine("1. {0}", row[2].ToString());
            Console.WriteLine("2. {0}", row[3].ToString());
            Console.WriteLine("3. {0}", row[4].ToString());

            AddAnswer(index);
        }
    }

    static void AddAnswer(int index)
    {
        Console.Write("answer: ");
        answer = Convert.ToInt32(Console.ReadLine());

        CheckAnswer(index);
    }

    static void CheckAnswer(int idx)
    {
        DataRow row = randomRows[idx];

        if (answer != Convert.ToInt32(row[5].ToString()))
        {
            returnScore--;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Correct Answer is: {0}) {1}", row[5], row[Convert.ToInt32(row[5]) + 1]);
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!");
            Console.ResetColor();
        }

        idx++;

        index = idx;

        if (index == Max_Score)
            GetLastAnswer();
    }

    static void GetLastAnswer()
    {
        if (Max_Score - 3 >= returnScore)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYour Score: {0}\nFailed! Try again!", returnScore);
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYour Score: {0}\nCongratulations, you got driving license!", returnScore);

            Console.ResetColor();
        }
    }
}