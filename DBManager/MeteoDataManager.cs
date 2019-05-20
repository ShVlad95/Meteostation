using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.DBManager
{
    public class MeteoDataManager
    {
        private MeteoStationDbContext _context;

        public async Task AddAsync(Datas data)
        {
            _context.Datas.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeAsync(Datas data, int id)
        {
            var foundRecord = _context.Datas.Where(r => r.Id == id)
                .FirstOrDefault();

            if (foundRecord == null)
                return;

            foundRecord = data;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var foundRecord = _context.Datas.Where(r => r.Id == id)
                .FirstOrDefault();

            if (foundRecord == null)
                return;

            _context.Datas.Remove(foundRecord);

            await _context.SaveChangesAsync();
        }

        public ICollection<Datas> GetAllResults()
        {
            return _context.Datas.ToList();
        }
    }
}
