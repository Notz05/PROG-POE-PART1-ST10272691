using System;
using System.Collections.Generic;

// Class to represent an ingredient
public class Ingredient
{
    public string Name { get; set; } 
    public double Quantity { get; set; } 
    public string Unit { get; set; } 

    // Constructor to initialize the ingredient
    public Ingredient(string name, double quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
}

// Class to represent a step in a recipe
public class RecipeStep
{
    public string Description { get; set; } 

    // Constructor to initialize the step
    public RecipeStep(string description)
    {
        Description = description;
    }
}

// Class to represent a recipe
public class Recipe
{
    public List<Ingredient> Ingredients { get; set; } 
    public List<RecipeStep> Steps { get; set; } 

    // Constructor to initialize the recipe
    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<RecipeStep>();
    }

    // Method to add an ingredient to the recipe
    public void AddIngredient(string name, double quantity, string unit){


        Ingredients.Add(new Ingredient(name, quantity, unit));
    }

    // Method to add a step to the recipe
    public void AddStep(string description)
    {
        Steps.Add(new RecipeStep(description));
    }

    // Method to display the recipe
    public void DisplayRecipe()
    {
        Console.WriteLine("Recipe:");
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
        Console.WriteLine("Are you sure you want to clear all data? (YES/N0)");
        string response = Console.ReadLine().ToUpper();
        if (response == "Y")
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
