/*Joshua John Pillai
 * ST10272691
 * PROG POE PART 1
 * Reference:
 * Troelsen, A. and Japikse, P. (2022) Pro C# 10 with .NET 6 Foundational Principles and Practices  in Programming. 11th edn. Chambersburg, PA: Apress. 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE_PART1_ST10272691
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Recipe Application");
                 Console.WriteLine("----------------------------");
                    Console.WriteLine("1. Add Ingredient");
                        Console.WriteLine("2. Add Step");
                             Console.WriteLine("3. Display Recipe");
                                 Console.WriteLine("4. Scale Recipe");
                                     Console.WriteLine("5. Reset Quantities");
                                         Console.WriteLine("6. Clear Recipe");
                                             Console.WriteLine("7. Exit");
                                                 Console.WriteLine("----------------------------");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // Logic for adding an ingredient
                        Console.Write("Enter ingredient name: ");
                        string ingredientName = Console.ReadLine();
                        double ingredientQuantity = GetUserInput("Enter quantity: ");
                        Console.Write("Enter unit: ");
                        string ingredientUnit = Console.ReadLine();
                        recipe.AddIngredient(ingredientName, ingredientQuantity, ingredientUnit);
                        Console.WriteLine("Ingredient added.");
                        break;
                    case "2":
                        // Logic for adding a step
                        Console.Write("Enter step description: ");
                        string stepDescription = Console.ReadLine();
                        recipe.AddStep(stepDescription);
                        Console.WriteLine("Step added.");
                        break;
                    case "3":
                        // Logic for displaying the recipe
                        Console.WriteLine("----------------------------");
                        recipe.DisplayRecipe();
                        Console.WriteLine("----------------------------");
                        break;
                    case "4":
                        // Logic for scaling the recipe
                        double scale = GetUserInput("Enter scaling factor (0.5, 2, or 3): ");
                        recipe.ScaleRecipe(scale);
                        Console.WriteLine($"Recipe scaled by a factor of {scale}.");
                        break;
                    case "5":
                        // Logic for resetting quantities
                        recipe.ResetQuantities();
                        break;
                    case "6":
                        // Logic for clearing the recipe
                        recipe.ClearRecipe();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Method to get user input for numeric values with error handling
       
        static double GetUserInput(string message)
        {
            double result;
            while (true)
            {
                Console.Write(message);
                
                if (double.TryParse(Console.ReadLine(), out result))
                {
                    
                    return result;
                }
                else
                {
                   
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }




    }
}
       