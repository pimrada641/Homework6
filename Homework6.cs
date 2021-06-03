using System;

namespace ConsoleApp13
{
    class Program
    {
        static int Scores;  //Score ในแต่ละรอบ
        enum Difficulty
        {
            Easy = 0,
            Normal = 1,
            Hard = 2
        }
        public static void Score(ref int Scores)
        {
            Scores += 1;
        }
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message,int answer)
            {
                Message = message;
                Answer = answer;
                Console.WriteLine(Message);

                Console.Write("Answer: ");
                int uranswer = int.Parse(Console.ReadLine());
                if(uranswer == Answer)
                {
                    Console.WriteLine("Correct! You got 1 score.\n");
                    Score(ref Scores);
                }
                else
                {
                    Console.WriteLine("Sorry, That's the wrong answer. You got no score.\n");
                }
            }
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for(int i=0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                        new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                        new Problem(String.Format("{0}-{1} = ?", x, y), x - y);
            }
            return randomProblems;
        }
        static void Main(string[] args)
        {
            double S = 0;//Score รวม
            int mode = 0;//ระดับความยาก
            int Ans=0; //ตัวเลือกหน้าหลัก
            while (Ans==0)
            {
            Console.WriteLine("-------[Main Menu]-------\n");

            Console.WriteLine("Score: {0}, Difficulty: {1}\n", S,(Difficulty)mode);
            int numProblem = 3 + mode * 2;

                    Console.WriteLine("What do you want to do?\n0: Start game\n1: Setting\n2: Exit");
                do
                {
                    Console.Write("Ans: ");
                    Ans = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (Ans!=0 && Ans != 1 && Ans != 2)
                    {
                        Console.WriteLine("!! Please Input 0-2 !!\n");
                    }
                } while (Ans != 0 && Ans != 1 && Ans != 2);
                if(Ans == 0)
                {
                    long time1 = DateTimeOffset.Now.ToUnixTimeSeconds();
                    GenerateRandomProblems(numProblem);
                    long time2 = DateTimeOffset.Now.ToUnixTimeSeconds();

                    double Q = (double)Scores / numProblem;
                    S += Q*((25-(double)Math.Pow(mode, 2))/Math.Max((time2-time1),(25 - (double)Math.Pow(mode, 2))))*Math.Pow(((2*mode)+1),2);
                    
                    Scores = 0;
                }
                else if(Ans == 1)
                {
                        Console.WriteLine("-------[Setting]-------\n");

                        Console.WriteLine("0: Easy\n1: Normal\n2: Hard");

                    do
                    {
                        Console.Write("Set your difficulty: ");
                        mode = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        if (mode != 0 && mode != 1 && mode != 2)
                        {
                            Console.WriteLine("!! Please Input 0-2 !!\n");
                        }
                    } while (mode != 0 && mode != 1 && mode != 2);
                    Ans = 0;
                }
                else if (Ans == 2)
                {
                    Console.Write("See you next time!\n");
                }
            }
        }
    }
}
