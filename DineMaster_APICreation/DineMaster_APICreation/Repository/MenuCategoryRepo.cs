using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;

namespace DineMaster_APICreation.Repository
{
    public interface MenuCategoryRepo
    {
        void AddCategory(MenuCategoryDTO dTO);
        List<CategoryMaster> GetCategory();
      
    }
}
