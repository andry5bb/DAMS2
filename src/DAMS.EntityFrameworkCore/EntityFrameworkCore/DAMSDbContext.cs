using Abp.EntityFrameworkCore;
using DAMS.EventReminder;
using DAMS.EventReminder.Event;
using DAMS.Models;
using Microsoft.EntityFrameworkCore;

namespace DAMS.EntityFrameworkCore
{
    public class DAMSDbContext : DbContext
    {
        //Add DbSet properties for your entities...
        public virtual DbSet<OneTimeEvent> OneTimeEvents { get; set; }
        public virtual DbSet<PeriodEvent> PeriodEvents { get; set; }
        //public virtual DbSet<CustomEvent> CustomEvents { get; set; }
        public virtual DbSet<CustomEventModel> CustomEventModels { get; set; }
        public DbSet<CustomEventDate> MyEventsModels { get; set; }


        public DAMSDbContext()
        {
            Database.EnsureCreated();
           // new DropCreateDatabaseIfModelChanges<SampleContext>()); // знаходе зміни в базі даних і у випадку знаходження сама перезаписує бд
        }
        // визов таблиці / сопоставление
        //protected override void OnModelCreating (ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CustomEvent>().ToTable("events");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=1234;database=DAMSa;");
        }



        public DAMSDbContext(DbContextOptions<DAMSDbContext> options) 
            : base(options)
        {
            
        }
    }
}
