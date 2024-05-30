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
            List<Recipes> recipes = new List<Recipes>();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Recipe Application");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Add Ingredient to a Recipe");
                Console.WriteLine("3. Add Step to a Recipe");
                Console.WriteLine("4. Display Recipes");
                Console.WriteLine("5. Display a Recipe");
                Console.WriteLine("6. Scale a Recipe");
                Console.WriteLine("7. Reset Quantities in a Recipe");
                Console.WriteLine("8. Clear a Recipe");
                Console.WriteLine("9. Exit");
                Console.WriteLine("----------------------------------------");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("----------------------------------------");
                        Console.Write("Enter the name of the recipe: ");
                        string recipeName = Console.ReadLine();
                        recipes.Add(new Recipes(recipeName));
                        Console.WriteLine("Recipe added successfully!");
                        break;

                    case "2":
                        Console.WriteLine("----------------------------------------");
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes available. Please add a recipe first.");
                            break;
                        }
                        Console.WriteLine("Select a recipe to add an ingredient to:");
                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                        }
                        int selectedRecipeIndex = int.Parse(Console.ReadLine()) - 1;
                        Recipes selectedRecipe = recipes[selectedRecipeIndex];
                        Console.Write("Enter the ingredient name: ");
                        string ingredientName = Console.ReadLine();
                        double quantity = selectedRecipe.GetUserInput("Enter the quantity: ");
                        Console.Write("Enter the unit of measurement: ");
                        string unit = Console.ReadLine();
                        int calories = (int)selectedRecipe.GetUserInput("Enter the number of calories: ");
                        Console.Write("Enter the food group: ");
                        string foodGroup = Console.ReadLine();
                        selectedRecipe.AddIngredient(ingredientName, quantity, unit, calories, foodGroup);
                        Console.WriteLine("Ingredient added successfully!");
                        break;

                    case "3":
                        Console.WriteLine("----------------------------------------");
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes available. Please add a recipe first.");
                            break;
                        }
                        Console.WriteLine("Select a recipe to add a step to:");
                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                        }
                        selectedRecipeIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedRecipe = recipes[selectedRecipeIndex];
                        Console.Write("Enter the step description: ");
                        string stepDescription = Console.ReadLine();
                        selectedRecipe.AddStep(stepDescription);
                        Console.WriteLine("Step added successfully!");
                        break;

                    case "4":
                        Console.WriteLine("----------------------------------------");
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes available.");
                            break;
                        }
                        Console.WriteLine("List of recipes:");
                        foreach (var recipe in recipes.OrderBy(r => r.Name))
                        {
                            Console.WriteLine(recipe.Name);
                        }
                        break;

                    case "5":
                        Console.WriteLine("----------------------------------------");
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes available. Please add a recipe first.");
                            break;
                        }
                        Console.WriteLine("Select a recipe to display:");
                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                        }
                        selectedRecipeIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedRecipe = recipes[selectedRecipeIndex];
                        selectedRecipe.DisplayRecipe();
                        Console.WriteLine($"Total Calories: {selectedRecipe.CalculateTotalCalories()}");
                        break;

                    case "6":
                        Console.WriteLine("----------------------------------------");
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes available. Please add a recipe first.");
                            break;
                        }
                        Console.WriteLine("Select a recipe to scale:");
                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                        }
                        selectedRecipeIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedRecipe = recipes[selectedRecipeIndex];
                        Console.WriteLine("Enter the scale factor (0.5 for half, 2 for double, 3 for triple): ");
                        double scaleFactor = double.Parse(Console.ReadLine());
                        selectedRecipe.ScaleRecipe(scaleFactor);
                        Console.WriteLine("Recipe scaled successfully!");
                        break;

                    case "7":
                        Console.WriteLine("----------------------------------------");
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes available. Please add a recipe first.");
                            break;
                        }
                        Console.WriteLine("Select a recipe to reset quantities:");
                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                        }
                        selectedRecipeIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedRecipe = recipes[selectedRecipeIndex];
                        selectedRecipe.ResetQuantities();
                        Console.WriteLine("Quantities reset successfully!");
                        break;

                    case "8":
                        Console.WriteLine("----------------------------------------");
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes available. Please add a recipe first.");
                            break;
                        }
                        Console.WriteLine("Select a recipe to clear:");
                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                        }
                        selectedRecipeIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedRecipe = recipes[selectedRecipeIndex];
                        selectedRecipe.ClearRecipe();
                        Console.WriteLine("Recipe cleared successfully!");
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}


