using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class RecipesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Recipes
        [ResponseType(typeof(List<RecipeModel>))]
        public IHttpActionResult GetCars()
        {
            return Ok(db.Recipe.ToList().ConvertAll(x => new RecipeModel(x)));
        }

        // GET: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult GetRecipe(int id)
        {
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT: api/Recipes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.idRecipe)
            {
                return BadRequest();
            }

            db.Entry(recipe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Recipes
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult PostRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipe.Add(recipe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipe.idRecipe }, recipe);
        }

        // DELETE: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult DeleteRecipe(int id)
        {
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipe.Remove(recipe);
            db.SaveChanges();

            return Ok(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeExists(int id)
        {
            return db.Recipe.Count(e => e.idRecipe == id) > 0;
        }
    }
}