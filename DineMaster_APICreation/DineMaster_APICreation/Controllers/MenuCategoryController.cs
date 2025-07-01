using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineMaster_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCategoryController : ControllerBase
    {
        MenuCategoryRepo repo;
        public MenuCategoryController(MenuCategoryRepo repo)
        { 
        this.repo= repo;
        }
        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory([FromBody] MenuCategoryDTO um)
        {
            repo.AddCategory(um);
            return Ok("category Added Sucessfully");
        }
        [HttpGet]
        [Route("GetCtegory")]
        public IActionResult GetMenuCategory()
        {
            var MCategory = repo.GetCategory();

            if (MCategory == null || !MCategory.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(MCategory);
        }
    }
}
