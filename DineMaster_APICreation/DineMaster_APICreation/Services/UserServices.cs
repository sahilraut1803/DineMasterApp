using DineMaster_APICreation.Data;
using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;
using Microsoft.EntityFrameworkCore;

namespace DineMaster_APICreation.Services
{
    public class UserServices:IUserRepo
    {
        ApplicationDbContext db;
        public UserServices(ApplicationDbContext db) 
        {
        this.db=db;
        }
     

   

      

        public void AddUser(UserDTO dto)
        {
            var user = new UserModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                Password = dto.Password,
                Role = dto.Role,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                UpdatedAt = null,
                UpdatedBy= null,

            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var medicine = db.Users.Find(id);
            if (medicine != null)
            {
                db.Users.Remove(medicine);
                db.SaveChanges();
            }
        }

        public UserModel GetUserByID(int id)
        {
            //var user = db.Users.FirstOrDefault(u => u.UserId == id);

            //if (user == null)
            //    return null;

            //return new UserModel
            //{
            //    UserId = user.UserId,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Username = user.Username,
            //    Password = user.Password, 
            //    Role = user.Role,
            //    IsActive = user.IsActive,
            //    CreatedAt = user.CreatedAt,
            //    CreatedBy = user.CreatedBy
            //};
            return db.Users.Find(id);
        }

        public List<UserDTO> GetUsers()
        {
            return db.Users.Select(u => new UserDTO
            {
                UserID = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                Password = u.Password,
                Role = u.Role,
                IsActive = u.IsActive,
                CreatedAt = u.CreatedAt,
                CreatedBy = u.CreatedBy
            }).ToList();
        }

        public void UpdateUser(UserModel um)
        {
            db.Users.Update(um);
            db.SaveChanges();
        }
    }
}
