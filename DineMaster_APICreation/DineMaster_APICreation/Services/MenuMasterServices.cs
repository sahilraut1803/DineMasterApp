using DineMaster_APICreation.Data;
using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;

namespace DineMaster_APICreation.Services
{
    public class MenuMasterServices : MenuMasterRepo
    {
        private readonly ApplicationDbContext _db;

        public MenuMasterServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddMenu(MenumasterDTO dto)
        {
            // Check if the CategoryID exists in CategoryMasters table
            var categoryExists = _db.CategoryMasters.Any(c => c.CategoryID == dto.CategoryID);

            if (!categoryExists)
            {
                throw new Exception($"CategoryID {dto.CategoryID} does not exist. Cannot add menu.");
                // Or handle gracefully if needed
            }

            var menu = new MenuMaster
            {
                MenuName = dto.MenuName,
                Description = dto.Description,
                MenuImage = dto.MenuImage,
                Prize = dto.Prize,
                CategoryID = dto.CategoryID,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                IsAvailable = true,
            };

            _db.MenuMaster.Add(menu);
            _db.SaveChanges();
        }

        public void DeleteMenu(int id)
        {
            var menu = _db.MenuMaster.Find(id);
            if (menu != null)
            {
                _db.MenuMaster.Remove(menu);
                _db.SaveChanges();
            }
        }

        public MenuMaster GetMenuByID(int id)
        {
            return _db.MenuMaster.Find(id);
        }

        public List<MenumasterDTO> GetMenuList()
        {
            return _db.MenuMaster.Select(u => new MenumasterDTO
            {
                MenuID = u.MenuID,
                CategoryID = u.CategoryID,
                MenuName = u.MenuName,
                MenuImage = u.MenuImage,
                Description = u.Description,
                Prize = u.Prize,
                IsAvailable = u.IsAvailable,
                CreatedAt = u.CreatedAt,
                CreatedBy = u.CreatedBy
            }).ToList();
        }

        public void UpdateMenu(MenuMaster updated)
        {
            // Check if the menu exists
            var existing = _db.MenuMaster.Find(updated.MenuID);
            if (existing == null)
            {
                throw new Exception($"Menu with ID {updated.MenuID} not found.");
            }

            // Check if the new CategoryID exists in the CategoryMasters table
            bool categoryExists = _db.CategoryMasters.Any(c => c.CategoryID == updated.CategoryID);
            if (!categoryExists)
            {
                throw new Exception($"Category with ID {updated.CategoryID} does not exist.");
            }

            // Update properties
            existing.MenuName = updated.MenuName;
            existing.Description = updated.Description;
            existing.MenuImage = updated.MenuImage;
            existing.Prize = updated.Prize;
            existing.CategoryID = updated.CategoryID;
            existing.IsAvailable = updated.IsAvailable;
            // Do not change CreatedAt or CreatedBy

            // Save changes
            _db.SaveChanges();
        }
    }
}
