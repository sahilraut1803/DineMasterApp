using DineMaster_APICreation.Data;
using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;

namespace DineMaster_APICreation.Services
{
    public class MenuCategoryServices:MenuCategoryRepo
    {
        ApplicationDbContext db;
        public MenuCategoryServices(ApplicationDbContext db) 
        {
        this.db = db;
        }

        public void AddCategory(MenuCategoryDTO dto)
        {

            var menu = new CategoryMaster
            {
                CategoryName = dto.CategoryName,
            };

            db.CategoryMasters.Add(menu);
            db.SaveChanges();
           
        }

     

        public List<CategoryMaster> GetCategory()
        {
            return db.CategoryMasters.Select(u => new CategoryMaster
            {
               CategoryName=u.CategoryName,
            }).ToList();
        }

     
    }
}
