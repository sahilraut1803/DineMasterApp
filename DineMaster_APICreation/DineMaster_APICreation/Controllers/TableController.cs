using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineMaster_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        ITableRepo repo;
        public TableController(ITableRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost("AddTable")]
        public async Task<IActionResult> AddTable(TableDTO1 dto)
        {
            await repo.AddTableAsync(dto);
            return Ok("Added Successfully");
        }

        [HttpGet("FetchTable")]
        public async Task<IActionResult> FetchTable()
        {
            var data = await repo.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("GetTable/{id}")]
        public async Task<IActionResult> GetTable(int id)
        {
            var data = await repo.GetTableByIdAsync(id);
            return Ok(data);
        }

        [HttpPut("UpdateTable")]
        public async Task<IActionResult> UpdateTable(TableDTO3 dto)
        {
            await repo.UpdateTableAsync(dto);
            return Ok("Updated Successfully");
        }

        [HttpDelete("DeleteTable/{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            int r = await repo.DeleteTableAsync(id);
            if (r > 0)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return NotFound("Cannot delete this record");
            }
        }
    }
}
