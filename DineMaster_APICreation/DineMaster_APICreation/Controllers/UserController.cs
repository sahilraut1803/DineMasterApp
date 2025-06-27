using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineMaster_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepo repo;

        public UserController(IUserRepo repo)
        {
            this.repo = repo;
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserDTO dto)
        {
            var data = new UserModel
            {
                Username=dto.Username,
                Password=dto.Password,
                Role=dto.Role,
                IsActive=true,
                CreatedAt=DateTime.Now,
                CreatedBy="system"


            };
            if(data!=null)
            {
                repo.AddUser(data);
                return Ok("User Added Successfully");
            }
            else
            {
                return NotFound("User Not Addedd");
            }
        }
    }
}
