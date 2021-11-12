using System;
using SQLite;

namespace RecipeApp.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        //public DateTime Date { get; set; }
        //public string Text { get; internal set; }
    }
}
