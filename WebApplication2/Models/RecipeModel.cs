using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RecipeModel
    {
        public RecipeModel(Recipe recipe)
        {
            idRecipe = recipe.idRecipe;
            fullRecipe = recipe.fullRecipe;
            nameRecipe = recipe.nameRecipe;

            image = recipe.image;

        }
        public int idRecipe { get; set; }
        public string fullRecipe { get; set; }
        public string nameRecipe { get; set; }
        public string image { get; set; }
    }
}