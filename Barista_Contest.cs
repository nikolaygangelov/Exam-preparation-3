using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    class Barista_Contest
    {
        static void Main(string[] args)
        {
            int[] queue = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            Queue<int> coffeQuantities = new Queue<int>(queue);

            int[] stack = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> milkQuantities = new Stack<int>(stack);

            Dictionary<string, int> countByBeverages = new Dictionary<string, int>();

            //int countOfDrinks = 0;

            while (coffeQuantities.Any() && milkQuantities.Any())//!!!!!!!!!!!!!
            {
                if ((int)coffeQuantities.Peek() + (int)milkQuantities.Peek() == 50)
                {
                    coffeQuantities.Dequeue();
                    milkQuantities.Pop();
                    if (!countByBeverages.ContainsKey("Cortado"))
                    {
                        countByBeverages["Cortado"] = 0;
                    }
                    countByBeverages["Cortado"]++;
                }
                else if ((int)coffeQuantities.Peek() + (int)milkQuantities.Peek() == 75)
                {
                    coffeQuantities.Dequeue();
                    milkQuantities.Pop();
                    if (!countByBeverages.ContainsKey("Espresso"))
                    {
                        countByBeverages["Espresso"] = 0;
                    }
                    countByBeverages["Espresso"]++;
                }
                else if ((int)coffeQuantities.Peek() + (int)milkQuantities.Peek() == 100)
                {
                    coffeQuantities.Dequeue();
                    milkQuantities.Pop();
                    if (!countByBeverages.ContainsKey("Capuccino"))
                    {
                        countByBeverages["Capuccino"] = 0;
                    }
                    countByBeverages["Capuccino"]++;
                }
                else if ((int)coffeQuantities.Peek() + (int)milkQuantities.Peek() == 150)
                {
                    coffeQuantities.Dequeue();
                    milkQuantities.Pop();
                    if (!countByBeverages.ContainsKey("Americano"))
                    {
                        countByBeverages["Americano"] = 0;
                    }
                    countByBeverages["Americano"]++;
                }
                else if ((int)coffeQuantities.Peek() + (int)milkQuantities.Peek() == 200)
                {
                    coffeQuantities.Dequeue();
                    milkQuantities.Pop();
                    if (!countByBeverages.ContainsKey("Latte"))
                    {
                        countByBeverages["Latte"] = 0;
                    }
                    countByBeverages["Latte"]++;
                }
                else
                {
                    coffeQuantities.Dequeue();
                    milkQuantities.Push(milkQuantities.Pop() - 5);
                }


            }

            if (!coffeQuantities.Any() && !milkQuantities.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (!coffeQuantities.Any())
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ",coffeQuantities)}");
            }

            if (!milkQuantities.Any())
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", coffeQuantities)}");
            }

            foreach (var item in countByBeverages.OrderBy(item => item.Value).ThenByDescending(item => item.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
