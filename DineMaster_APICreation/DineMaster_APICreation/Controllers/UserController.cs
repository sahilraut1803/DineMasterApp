using AutoMapper;
using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;
using DineMaster_APICreation.Services;
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
        public IActionResult AddUser([FromBody] UserDTO um)
        {

            repo.AddUser(um);
            return Ok("User Added Sucessfully");
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = repo.GetUsers();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        [HttpGet]
        [Route("GetUserByID{id}")]
        public IActionResult getUserbyID(int id) 
        { 
        var user= repo.GetUserByID(id);
            if (user == null) 
            {
                return BadRequest("User Not Found");
            }

            return Ok(user);
        
        }


        [HttpPut]
        [Route("UpdateUser{id}")]
        public IActionResult Update(int id,UserDTO dto)
        {
            if (id != dto.UserID) return BadRequest("Id mismatch");
            var user = repo.GetUserByID(id);

            if (user == null) return NotFound("user does not exixts");
           // Source is dto, Target is model

            //            if (medicine == null) return NotFound("Medine does not exixts");
            //            mapper.Map(dto, medicine); 

            dto.UpdatedAt = DateTime.Now;
            dto.UpdatedBy = dto.UpdatedBy ?? "Defaultuser";
            repo.UpdateUser(user);
            return Ok("User Updated Sucessfully");
        }


        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult Delete(int id) 
        {
        var user=repo.GetUserByID(id);
            if (user == null) return NotFound("User not found");
            repo.DeleteUser(id);
            return Ok("User zdeleted Successfully");
        }
    }
}
