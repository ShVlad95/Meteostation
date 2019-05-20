using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using test.DBManager;

namespace test.Models
{
    public partial class MeteoStationDbContext : DbContext, IDbManager
    {
        public MeteoStationDbContext()
        {
        }

        public MeteoStationDbContext(DbContextOptions<MeteoStationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Datas> Datas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\DEVELOPMENT;Database=MeteoStationDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datas>(entity =>
            {
                entity.Property(e => e.Co).HasColumnName("CO");

                entity.Property(e => e.DataSaveTime).HasColumnType("datetime");
            });
        }

        public async Task AddAsync(Datas data)
        {
            Datas.Add(data);
            await SaveChangesAsync();
        }

        public async Task ChangeAsync(Datas data, int id)
        {
            var foundRecord = await Datas.FindAsync(id);

            if (foundRecord == null)
                return;

            //todo: поидее здесь должен срабатывать конструктор по умолчанию.
            foundRecord = new Datas()
            {
                Co = data.Co,
                Humidity = data.Humidity,
                Pressure = data.Pressure,
                Temperature = data.Temperature,
                DataSaveTime = data.DataSaveTime
            };

            SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var foundRecord = Datas.Where(r => r.Id == id)
                .FirstOrDefault();

            if (foundRecord == null)
                return;

            Datas.Remove(foundRecord);

            await SaveChangesAsync();
        }

        public async Task<ICollection<Datas>> GetAllResultsAsync()
        {
            return await Datas.ToListAsync();
        }
    }
}
