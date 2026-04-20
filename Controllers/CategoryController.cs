using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_dotnet_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_dotnet_core.Controllers
{


    [ApiController]
    [Route("api/categories/")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();


        //get all categories=>api/categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(categories);
        }


        //post a new category => api/categories
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = category.Name,
                Description = category.Description,
                CreatedAt = DateTime.UtcNow
            };

            if (string.IsNullOrEmpty(newCategory.Name) || string.IsNullOrEmpty(newCategory.Description))
            {
                return BadRequest("Category name and description are required.");
            }
            if (categories.Any(c => c.Name != null && c.Name.Equals(newCategory.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict("A category with the same name already exists.");
            }

            categories.Add(newCategory);
            return Created($"/api/categories/{newCategory.CategoryId}", newCategory);
        }



        //get category by id

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(Guid id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        //delete category by id

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            categories.Remove(category);
            return NoContent();
        }


        //update category by id
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(Guid id, [FromBody] Category updatedCategory)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;

            return Ok(category);
        }


        //search categories by name
        [HttpGet("search")]
        public IActionResult SearchCategories([FromQuery] string name)
        {
            var matchedCategories = categories
                .Where(c => c.Name != null &&
                            c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(matchedCategories);
        }

    }
}