using DineMaster_APICreation.Data;
using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;

namespace DineMaster_APICreation.Services
{
    public class UserServices:IUserRepo
    {
        ApplicationDbContext db;
        public UserServices(ApplicationDbContext db) 
        {
        this.db=db;
        }
     

        public void AddUser(object data)
        {
            if (data != null) 
            {
                db.Users.Add((UserModel)data);
                db.SaveChanges();
            }
        }
    }
}
