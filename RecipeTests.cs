using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PROG_POE_PART1_ST10272691;
using Microsoft.VisualStudio.TestTools.UnitTesting; 

namespace PROG_POE_PART1_ST10272691
{
    internal class RecipeTests
    {
        public class Program
        {
            [TestMethod]
            public void TestTotalCalories()
            {
                // Arrange
                Recipes recipe = new Recipes("Test Recipe");
                recipe.AddIngredient("Sugar", 1, "cup", 200, "Carbohydrates");
                recipe.AddIngredient("Butter", 0.5, "cup", 400, "Fats");

                // Act
                int totalCalories = recipe.CalculateTotalCalories();

                // Assert
                Assert.AreEqual(600, totalCalories);
            }

            [TestMethod]
            public void TestTotalCaloriesExceedsLimit()
            {
                // Arrange
                Recipes recipe = new Recipes("High Calorie Recipe");
                recipe.AddIngredient("Sugar", 2, "cup", 400, "Carbohydrates");
                recipe.AddIngredient("Butter", 1, "cup", 800, "Fats");

                bool notificationCalled = false;

                // Delegate method to set notificationCalled to true
                recipe.NotifyCalories += (message) => { notificationCalled = true; };

                // Act
                int totalCalories = recipe.CalculateTotalCalories();

                // Assert
                Assert.IsTrue(notificationCalled);
                Assert.AreEqual(1200, totalCalories);
            }

            [TestMethod]
            public void TestScalingRecipe()
            {
                // Arrange
                Recipes recipe = new Recipes("Scaling Test Recipe");
                recipe.AddIngredient("Flour", 2, "cup", 400, "Grains");
                recipe.AddIngredient("Milk", 1, "cup", 150, "Dairy");

                // Act
                recipe.ScaleRecipe(2); // Scale by a factor of 2

                // Assert
                Assert.AreEqual(4, recipe.Ingredients[0].Quantity); // Flour should be doubled
                Assert.AreEqual(2, recipe.Ingredients[1].Quantity); // Milk should be doubled
            }

            [TestMethod]
            public void TestResetQuantities()
            {
                // Arrange
                Recipes recipe = new Recipes("Reset Quantities Test Recipe");
                recipe.AddIngredient("Flour", 2, "cup", 400, "Grains");
                recipe.AddIngredient("Milk", 1, "cup", 150, "Dairy");

                // Act
                recipe.ResetQuantities();

                // Assert
                foreach (var ingredient in recipe.Ingredients)
                {
                    Assert.AreEqual(1, ingredient.Quantity); // Quantities should be reset to 1
                }
            }

            [TestMethod]
            public void TestClearRecipe()
            {
                // Arrange
                Recipes recipe = new Recipes("Clear Recipe Test");
                recipe.AddIngredient("Flour", 2, "cup", 400, "Grains");
                recipe.AddStep("Mix ingredients");

                // Act
                recipe.ClearRecipe();

                // Assert
                Assert.AreEqual(0, recipe.Ingredients.Count); // Ingredients list should be empty
                Assert.AreEqual(0, recipe.Steps.Count); // Steps list should be empty
            }
        }
    }
}
