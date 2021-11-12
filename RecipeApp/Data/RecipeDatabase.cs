﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using RecipeApp.Models;


namespace RecipeApp.Data
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public RecipeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe>().Wait();


        }
        public Task<List<Recipe>> GetRecipeAppAsync()
        {
            //Get all recipes.
            return database.Table<Recipe>().ToListAsync();
        }
        public Task<Recipe> GetRecipeAsync(int id)
        {
            // Get a specific recipe.
            return database.Table<Recipe>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            if (recipe.ID != 0)
            {
                // Update an existing recipe.
                return database.UpdateAsync(recipe);
            }
            else
            {
                // Save a new recipe.
                return database.InsertAsync(recipe);
            }
        }
        public Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            // Delete a recipe.
            return database.DeleteAsync(recipe);
        }
    }

}

