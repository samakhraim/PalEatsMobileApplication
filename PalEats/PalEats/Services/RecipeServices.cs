using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using PalEats.Models;
namespace PalEats.Services
{
    public class RecipeServices
    {
        string connectionString = "Data Source=paleatserver.database.windows.net;Initial Catalog=PalEatsDB;Persist Security Info=True;User ID=sama;Password=S11a7m2!a000";
        public async Task<RecipeModel> GetRecipesAsync(int id)
        {
            RecipeModel recipe = new RecipeModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Dish WHERE DishId=" + id;
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        recipe = new RecipeModel
                        {
                            DishId = Convert.ToInt32(reader["DishId"]),
                            DishName = reader["DishName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Preparation = reader["Preparation"].ToString(),
                            NumberOfPeople = reader["NumberOfPeople"].ToString(),
                            Calories = reader["Calories"].ToString(),
                            DueTime = reader["DueTime"].ToString(),
                            DishImgUrl = reader["DishImgUrl"].ToString(),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        };
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("SQL Error fetching recipes: " + ex.Message);
                throw new Exception("SQL Error: Failed to fetch recipes. Message: " + ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error fetching recipes: " + ex.Message);
                throw new Exception("Failed to fetch recipes. Message: " + ex.Message);
            }

            return recipe;
        }
        public async Task<List<IngredientsModel>> GetIngredientsAsync(int id)
        {
            List<IngredientsModel> ingredients = new List<IngredientsModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT Ingredients.IngredientsName, DishIngredients.Amount FROM DishIngredients INNER JOIN Ingredients ON DishIngredients.IngredientsId = Ingredients.IngredientsId  where DishId = " + id;
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        IngredientsModel ingredient = new IngredientsModel
                        {

                            Description = reader["Amount"].ToString() + " " + reader["IngredientsName"].ToString(),

                        };
                        ingredients.Add(ingredient);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("SQL Error fetching recipes: " + ex.Message);
                throw new Exception("SQL Error: Failed to fetch recipes. Message: " + ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error fetching recipes: " + ex.Message);
                throw new Exception("Failed to fetch recipes. Message: " + ex.Message);
            }
            ingredients.ForEach(recipe =>
            {
                Console.WriteLine("mmmmmmmmm" + recipe.Description);
            });
            return ingredients;
        }
    }
}