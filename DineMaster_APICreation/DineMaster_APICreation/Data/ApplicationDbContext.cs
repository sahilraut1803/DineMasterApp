using Microsoft.EntityFrameworkCore;
using DineMaster_APICreation.Models;
namespace DineMaster_APICreation.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryMaster> CategoryMasters { get; set; }
        public DbSet<MenuMaster> MenuMaster { get; set; }
        public DbSet<MenuIngradients> MenuIngradients { get; set; }
        public DbSet<IngradientMaster> IngradientMaster { get; set; }
        public DbSet<OnlineOrder> OnlineOrder { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }


        public DbSet<OrderTracking> OrderTracking { get; set; }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Reservation-Table
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TableId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
