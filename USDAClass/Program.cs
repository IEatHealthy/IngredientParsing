using System;
using System.IO; 
using System.Collections.Generic;

namespace USDAClass
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("ABBREV.txt");
            StreamWriter sw = new StreamWriter("USDAOutput.txt");
            List<ParserClass> Ingredients = new List<ParserClass>();

            string data = sr.ReadLine();
            while (data != null)
            {
                ParserClass test = new ParserClass(data, sr, sw);
                Ingredients.Add(test);
                data = sr.ReadLine();
            }
            string name = "";
            do
            {
                Console.WriteLine("Enter an ingredient name:");
                name = Console.ReadLine();
                name = name.ToUpper();
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    if (Ingredients[i].Shrt_Desc.Contains(name))
                        Console.WriteLine(Ingredients[i].Shrt_Desc);
                }
            } while (name != "q");
        }
    }
}
