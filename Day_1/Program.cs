using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode_2022
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who is carrying the most food in calories?");

            try
            {
                Dictionary<string, int> elfList = new Dictionary<string, int>();
   
                CalculateCalories(elfList);
                DisplayElfCalories(elfList);

                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
            }  
        }

        public static Dictionary<string, int> CalculateCalories(Dictionary<string, int> elfList)
        {
            var elfCounter = 1;
            var calorieTotal = 0;

            foreach (var calorie in File.ReadLines("calories_input.txt"))
            {
                if(elfCounter == 224)
                {
                    var test = "";
                }

                if (!string.IsNullOrEmpty(calorie))
                {
                    calorieTotal += Int32.Parse(calorie);
                }

                // We've hit an empty line, end of elf
                // calculate elf's calorie count
                else
                {
                    elfList.Add(String.Format("Elf {0}", elfCounter), calorieTotal);
                    elfCounter++;
                    calorieTotal = 0;
                }     
            }

            // One final add, could evaluate if we're end of file on File reader - but this works too
            elfList.Add(String.Format("Elf {0}", elfCounter), calorieTotal);

            return elfList;
        }

        public static void DisplayElfCalories(Dictionary<string, int> elfList)
        {
            foreach (var elf in elfList.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("{0} : {1}", elf.Key, elf.Value);
            }

            Console.WriteLine("The elf with the most calories is {0}", elfList.OrderByDescending(x => x.Value).First());

            Console.ReadKey();
        }
    }
}
