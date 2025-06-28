using DineMaster_APICreation.DTO;

namespace DineMaster_APICreation.Repository
{
    public interface IReservationRepo
    {
        Task AddReservationAsync(ReservationDTO1 reservation);
        Task<List<ReservationDTO2>> GetAllAsync();
        Task<ReservationDTO3> GetReservationByIdAsync(int id);
        Task UpdateReservationAsync(ReservationDTO3 reservation);
        Task<int> DeleteReservationAsync(int id);
    }
}
