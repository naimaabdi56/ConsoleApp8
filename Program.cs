using System;

class StudentQuizSystem
{
    static void Main()
    {
        // Akhri magaca iyo ID-ga
        Console.Write("Gali magacaaga: ");
        string name = Console.ReadLine();

        Console.Write("Gali ID-gaaga: ");
        string id = Console.ReadLine();

        // Doorashada hal mar ah
        Console.WriteLine("\nDooro nooca xisaabta aad rabto:");
        Console.WriteLine("1. Kudar (+)");
        Console.WriteLine("2. Ka jar (-)");
        Console.WriteLine("3. Ku dhufso (*)");
        Console.WriteLine("4. Qeybi (/)");

        string operation = "";
        if (!int.TryParse(Console.ReadLine(), out int opChoice) || opChoice < 1 || opChoice > 4)
        {
            Console.WriteLine("Doorasho khaldan. Barnaamijku wuu xirmayaa.");
            return;
        }

        switch (opChoice)
        {
            case 1: operation = "+"; break;
            case 2: operation = "-"; break;
            case 3: operation = "*"; break;
            case 4: operation = "/"; break;
        }

        Random rand = new Random();
        int score = 0;
        int totalQuestions = 10;

        for (int i = 1; i <= totalQuestions; i++)
        {
            int a = rand.Next(1, 50);
            int b = rand.Next(1, 50);

            // Si looga fogaado 0 marka la qeybinayo
            if (operation == "/" && b == 0) b = 1;

            double correctAnswer = 0;
            switch (operation)
            {
                case "+": correctAnswer = a + b; break;
                case "-": correctAnswer = a - b; break;
                case "*": correctAnswer = a * b; break;
                case "/": correctAnswer = Math.Round((double)a / b, 2); break;
            }

            // Weydiinta su’aasha
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

        Console.WriteLine("\nOutput:");
        Console.WriteLine("Magaca\tID\tT.Sax\tT.Khalad\tBoqolley");
        double percent = (score / (double)totalQuestions) * 100;
        Console.WriteLine($"{name}\t{id}\t{score}\t{totalQuestions - score}\t\t{percent}");

    }
}
