using System;

class StudentQuizSystem
{
    static void Main()
    {
        string name = GetStudentName();
        string id = GetStudentID();
        string operation = ChooseOperation();

        int score = AskQuestions(operation, 10);
        ShowResults(name, id, score, 10);
    }

    static string GetStudentName()
    {
        Console.Write("Gali magacaaga: ");
        return Console.ReadLine();
    }

    static string GetStudentID()
    {
        Console.Write("Gali ID-gaaga: ");
        return Console.ReadLine();
    }

    static string ChooseOperation()
    {
        Console.WriteLine("\nDooro nooca xisaabta aad rabto:");
        Console.WriteLine("1. Kudar (+)");
        Console.WriteLine("2. Ka jar (-)");
        Console.WriteLine("3. Ku dhufso (*)");
        Console.WriteLine("4. Qeybi (/)");

        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Doorasho khaldan. Barnaamijka wuu xirmayaa.");
            Environment.Exit(0);
        }

        switch (choice)
        {
            case 1: return "+";
            case 2: return "-";
            case 3: return "*";
            case 4: return "/";
            default: return "+";
        }
    }

    static int AskQuestions(string operation, int totalQuestions)
    {
        Random rand = new Random();
        int score = 0;

        for (int i = 1; i <= totalQuestions; i++)
        {
            int a = rand.Next(1, 50);
            int b = rand.Next(1, 50);
            if (operation == "/" && b == 0) b = 1;

            double correctAnswer = CalculateAnswer(a, b, operation);

            Console.Write($"{a} {operation} {b} = ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double userAnswer))
            {
                if (Math.Abs(userAnswer - correctAnswer) < 0.01)
                {
                    Console.WriteLine("Sax");
                    score++;
                }
                else
                {
                    Console.WriteLine("Khalad");
                    Console.WriteLine($"Jawaabta saxda ah waa: {correctAnswer}");
                }
            }
            else
            {
                Console.WriteLine("Fadlan geli tiro sax ah");
            }
        }

        return score;
    }

    static double CalculateAnswer(int a, int b, string operation)
    {
        return operation switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => Math.Round((double)a / b, 2),
            _ => 0
        };
    }

    static void ShowResults(string name, string id, int score, int totalQuestions)
    {
        int wrong = totalQuestions - score;
        double percent = (score / (double)totalQuestions) * 100;

        Console.WriteLine("\nOutput:");
        Console.WriteLine("Magaca\tID\tT.Sax\tT.Khalad\tBoqolley");
        Console.WriteLine($"{name}\t{id}\t{score}\t{wrong}\t\t{percent}");
    }
}

