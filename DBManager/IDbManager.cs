using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.DBManager
{
    public interface IDbManager
    {
        Task AddAsync(Datas data);
        Task ChangeAsync(Datas data, int id);
        Task DeleteAsync(int id);
        Task<ICollection<Datas>> GetAllResultsAsync();
    }
}
