using Assignment.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class SQLiteHeler
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHeler(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Hike>();
        }

        public Task<int> CreateHike(Hike h)
        {
            return db.InsertAsync(h);
        }

        public Task<List<Hike>> GetAllHike()
        {
            return db.Table<Hike>().ToListAsync();
        }

        public Task<int> UpdateHike(Hike h)
        {
            return db.UpdateAsync(h);
        }

        public Task<int> DeleteHike(Hike h)
        {
            return db.DeleteAsync(h);
        }
    }
}
