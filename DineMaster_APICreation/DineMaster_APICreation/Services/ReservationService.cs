﻿using AutoMapper;
using DineMaster_APICreation.Data;
using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;
using DineMaster_APICreation.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DineMaster_APICreation.Services
{
    public class ReservationService : IReservationRepo
    {
        ApplicationDbContext db;
        IMapper mapper;
        public ReservationService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public async Task AddReservationAsync(ReservationDTO1 reservation)
        {
            var data = mapper.Map<Reservation>(reservation);

            data.CreatedAt = DateTime.Now;

            await db.Reservations.AddAsync(data);
            await db.SaveChangesAsync();
        }
        public async Task<List<ReservationDTO2>> GetAllAsync()
        {
            var data = await db.Reservations.Include(x => x.Table).ToListAsync();
            var reservation = mapper.Map<List<ReservationDTO2>>(data);
            return reservation;
        }
        public async Task<ReservationDTO3> GetReservationByIdAsync(int id)
        {
            var data = await db.Reservations.FindAsync(id);
            var reservation = mapper.Map<ReservationDTO3>(data);
            return reservation;
        }
        public async Task UpdateReservationAsync(ReservationDTO3 reservation)
        {
            var existing = await db.Reservations.FirstOrDefaultAsync(x => x.ReservationId == reservation.ReservationId);
            if (existing != null)
            {
                existing.CustomerName = reservation.CustomerName;
                existing.Contact = reservation.Contact;
                existing.GuestsCount = reservation.GuestsCount;
                existing.Status = reservation.Status;
                existing.StartTime = reservation.StartTime;
                existing.EndTime = reservation.EndTime;
                existing.TableId = reservation.TableId;
                existing.ModifiedAt = DateTime.Now;
                existing.ModifiedBy = reservation.ModifiedBy;

                await db.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteReservationAsync(int id)
        {
            var reservation = await db.Reservations.FindAsync(id);
            try
            {
                db.Reservations.Remove(reservation);
                await db.SaveChangesAsync();
                return 1;
            }
            catch (SqlException e)
            {
                return 0;
            }
        }
        public async Task<List<TableDTO2>> GetAvailableTableAsync()
        {
            var data = await db.Tables.Where(x=>x.Status!="Maintenance").ToListAsync();
            var table = mapper.Map<List<TableDTO2>>(data);
            return table;
        }

        public async Task<List<TableDTO2>> GetSuitableTableAsync(ReservationDTO4 reservation)
        {
            var availableTables = await db.Tables
                .Where(t =>
                    t.Capacity >= reservation.GuestsCount &&
                    t.Status != "Maintenance" &&
                    !db.Reservations.Any(r =>
                        r.TableId == t.TableId &&
                        r.Status != "Cancelled" &&
                        reservation.StartTime < r.EndTime &&
                        reservation.EndTime > r.StartTime
                    )
                )
                .OrderBy(t => t.Capacity)
                .ToListAsync();

            var data = mapper.Map<List<TableDTO2>>(availableTables);
            return data;
        }

        public async Task<bool> CheckInAsync(int id)
        {
            var reservation = await db.Reservations.FindAsync(id);
            if (reservation == null || reservation.Status != "Booked")
            {
                return false;
            }
            reservation.Status = "Seated";

            var table = await db.Tables.FindAsync(reservation.TableId);
            if (table != null)
            {
                table.Status = "Occupied";
            }
            OrderDTO1 order = new OrderDTO1();
            order.TableId = reservation.TableId;
            order.OrderType = "Dine in";
            order.OrderedBy = reservation.CustomerName;
            order.OrderDate=DateTime.Now;
            order.OrderStatus = "pending";
            var data = mapper.Map<Order>(order);
            await db.Orders.AddAsync(data);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckOutAsync(int id)
        {
            var reservation = await db.Reservations.FindAsync(id);
            if (reservation == null || reservation.Status != "Seated")
            {
                return false;
            }
            reservation.Status = "Completed";

            var table = await db.Tables.FindAsync(reservation.TableId);
            if (table != null)
            {
                table.Status = "Available";
            }
            await db.SaveChangesAsync();
            return true;
        }

    }
}
