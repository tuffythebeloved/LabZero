
using System.Numerics;
using System.Xml.Schema;
/**
*outputs high and low ints
*Author:Thalia Munroe
*Version: January 15th, 2024 - V1.0
**/
namespace LabZero
{
    class Program
    {
        static void Main(string[] args)
        {
            var P = new Program();
            /** Task 1: Without Loop
            Console.WriteLine("Please input your low number");
            if (int.TryParse(Console.ReadLine(), out int lowNum))
            {
                if (lowNum < 0)
                {
                Console.WriteLine("please make interger value positive");
                Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please input your high number");
                    if (int.TryParse(Console.ReadLine(), out int highNum))
                    {
                        if (highNum < 0)
                        {
                            Console.WriteLine("please make interger value positive");
                            Environment.Exit(0);
                        }
                        else if (highNum < lowNum)
                        {
                            Console.WriteLine("please make your high number, higher than your low number");
                            Environment.Exit(0);
                        }
                        else
                        {
                            int difference = highNum - lowNum;
                            Console.WriteLine("The difference between the high and low value is: " + difference);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Not a valid integer");
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: Not a valid integer");
                Environment.Exit(0);
            }
            **/

            //Task 2: With Loop
            int lowNum = P.GetLowNumber();
            int highNum = P.GetHighNumber(lowNum);

            //Task 3: Add Arrays and file(used lists instead to simplify method)
            List<int> difference = P.CountDifference(lowNum, highNum);

            P.WriteToFile(difference, "../../../res/number.txt");

            List<int> inverse = P.ReadFromFile("../../../res/number.txt");

            int totalInBetween = 0;

            foreach(int i in inverse)
            {
                totalInBetween += i;
            }

            Console.WriteLine("the sum of the inbetween numbers is: " + totalInBetween);

            Console.WriteLine("here are prime numbers between " + lowNum + " and " + highNum + ":");
            foreach(int i in difference)
            {
                if(P.isPrime(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        int GetLowNumber()
        {
            Console.WriteLine("Please input your low number");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int lowNum))
                {
                    if (lowNum > 0)
                    {
                        return lowNum;
                    }
                    else
                    {
                        Console.WriteLine("please make interger value positive");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Not a valid integer");
                }
            }
        }
        int GetHighNumber(int lowNum)
        {
            Console.WriteLine("Please input your high number");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int highNum))
                {
                    if (highNum < 0)
                    {
                        Console.WriteLine("please make interger value positive");
                    }
                    else if(highNum < lowNum)
                    {
                        Console.WriteLine("please make your high number, higher than your low number");
                    }
                    else
                    {
                        return highNum;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Not a valid integer");
                }
            }
        }
        List<int> CountDifference(int lowNum, int highNum)
        {
            List<int> differnce = new List<int>();

            for(int i = (lowNum + 1); i < highNum; i++)
            {
                differnce.Add(i);
            }
            return differnce;
        }
        void WriteToFile(List<int> difference, string textFilePath)
        {
            int highestNum = difference[difference.Count - 1];

            if (File.Exists(textFilePath))
            {
                File.Delete(textFilePath);
            }

            using (StreamWriter sw = new StreamWriter(textFilePath))
            {
                for (int i = highestNum; i >= difference[0]; i--)
                {
                    if(i > difference[0])
                    {
                        sw.Write(i.ToString() + ",");
                    }
                    else
                    {
                        sw.Write(i.ToString());
                    }
                }

            }
                
        }
        List<int> ReadFromFile(string textFilePath)
        {
            List<int> inverse = new List<int>();

            using(StreamReader sr = new StreamReader(textFilePath))
            {
                string[] inverseStrings = sr.ReadLine().Split(',');

                foreach (string line in inverseStrings)
                {
                    inverse.Add(int.Parse(line));
                }
            }

            return inverse;

        }
        bool isPrime(int Num)
        {
            bool prime = true;
            if (Num < 2 || (Num % 1) > 0)
            {
                prime = false;
            }
            else
            {
                for(int i = 2; i < Num; i++)
                {
                    if(Num % i == 0)
                    {
                        prime = false;
                    }
                }
            }
            return prime;
            
        }
    }



}