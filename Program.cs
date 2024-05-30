using System;
using System.Collections.Generic;
using System.Linq;

// Class to represent an ingredient
public class Ingredient
{
    public string Name { get; set; } // Name of the ingredient
    public double Quantity { get; set; } // Quantity of the ingredient
    public string Unit { get; set; } // Unit of measurement for the quantity
    public int Calories { get; set; } // Number of calories
    public string FoodGroup { get; set; } // Food group

    // Constructor to initialize the ingredient
    public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        Calories = calories;
        FoodGroup = foodGroup;
    }
}

// Class to represent a step in a recipe
public class RecipeStep
{
    public string Description { get; set; } // Description of the step

    // Constructor to initialize the step
    public RecipeStep(string description)
    {
        Description = description;
    }
}

// Class to represent a recipe
public class Recipes
{
    public string Name { get; } // Name of the recipe
    public List<Ingredient> Ingredients { get; set; } // List of ingredients in the recipe
    public List<RecipeStep> Steps { get; set; } // List of steps in the recipe
    public delegate void CalorieNotification(string message);
    public event CalorieNotification NotifyCalories;

    // Constructor to initialize the recipe
    public Recipes(string name)
    {
        Name = name;
        Ingredients = new List<Ingredient>();
        Steps = new List<RecipeStep>();
    }

    // Method to add an ingredient to the recipe
    public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
    {
        Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
    }

    // Method to add a step to the recipe
    public void AddStep(string description)
    {
        Steps.Add(new RecipeStep(description));
    }

    // Method to calculate the total calories of the recipe
    public int CalculateTotalCalories()
    {
        int totalCalories = Ingredients.Sum(ingredient => ingredient.Calories);
        if (totalCalories > 300)
        {
            NotifyCalories?.Invoke("Warning: Total calories exceed 300!");
        }
        return totalCalories;
    }

    // Method to display the recipe
    public void DisplayRecipe()
    {
        Console.WriteLine($"Recipe: {Name}");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }
        Console.WriteLine("Steps:");
        for (int i = 0; i < Steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Steps[i].Description}");
        }
    }

    // Method to scale the recipe quantities by a given factor
    public void ScaleRecipe(double factor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    // Method to reset ingredient quantities to their original values
    public void ResetQuantities()
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity = 1; // Reset quantities to 1
        }
        Console.WriteLine("Quantities reset to original values.");
    }

    // Method to clear all data in the recipe
    public void ClearRecipe()
    {
        Console.WriteLine("Are you sure you want to clear all data? (YES/NO)");
        string response = Console.ReadLine().ToUpper();
        if (response == "YES")
        {
            Ingredients.Clear(); // Clear all ingredients
            Steps.Clear(); // Clear all steps
            Console.WriteLine("All data cleared.");
        }
        else
        {
            Console.WriteLine("Clearing cancelled.");
        }
    }


// Method to get user input for numeric values with error handling
public double GetUserInput(string message)
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