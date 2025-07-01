using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;

namespace DineMaster_APICreation.Repository
{
    public interface MenuMasterRepo
    {
        void AddMenu(MenumasterDTO dto);
        List<MenumasterDTO> GetMenuList();

        MenuMaster GetMenuByID(int id);
        void UpdateMenu(MenuMaster mm);

        void DeleteMenu(int id);    

    }
}
