﻿using DineMaster_APICreation.DTO;

namespace DineMaster_APICreation.Repository
{
    public interface ITableRepo
    {
        Task AddTableAsync(TableDTO1 table);
        Task<List<TableDTO2>> GetAllAsync();
        Task<TableDTO3> GetTableByIdAsync(int id);
        Task UpdateTableAsync(TableDTO3 table);
        Task<int> DeleteTableAsync(int id);
    }
}
