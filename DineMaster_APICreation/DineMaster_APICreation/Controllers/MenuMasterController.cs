using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DineMaster_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuMasterController : ControllerBase
    {
        private readonly MenuMasterRepo repo;

        public MenuMasterController(MenuMasterRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("AddMenu")]
        public IActionResult AddMenu([FromBody] MenumasterDTO dto)
        {
            repo.AddMenu(dto);
            return Ok("Menu added successfully.");
        }

        [HttpGet]
        [Route("GetMenuList")]
        public IActionResult GetMenuList()
        {
            var menuList = repo.GetMenuList();

            if (menuList == null || !menuList.Any())
            {
                return NotFound("No menus found.");
            }

            return Ok(menuList);
        }

        [HttpDelete]
        [Route("DeleteMenu")]
        public IActionResult DeleteMenu(int id)
        {
            var menu = repo.GetMenuByID(id);

            if (menu == null)
            {
                return NotFound("Menu not found.");
            }

            repo.DeleteMenu(id);
            return Ok("Menu deleted successfully.");
        }

        [HttpGet]
        [Route("GetMenuByID")]
        public IActionResult GetMenuByID(int id)
        {
            var menu = repo.GetMenuByID(id);

            if (menu == null)
            {
                return NotFound("Menu not found.");
            }

            return Ok(menu);
        }

        [HttpPut]
        [Route("UpdateMenu{id}")]
        public IActionResult UpdateMenu(int id, [FromBody] MenuMaster mm)
        {
            if (id != mm.MenuID)
            {
                return BadRequest("ID mismatch.");
            }

            var existingMenu = repo.GetMenuByID(id);
            if (existingMenu == null)
            {
                return NotFound("Menu does not exist.");
            }

            mm.UpdatedAt = DateTime.Now;
            mm.UpdatedBy = mm.UpdatedBy ?? "DefaultUser";

            repo.UpdateMenu(mm);
            return Ok("Menu updated successfully.");
        }
    }
}
