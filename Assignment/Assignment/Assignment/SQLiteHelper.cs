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

        public Task<int> CreateHike(Hike hike)
        {
            return db.InsertAsync(hike);
        }

        public Task<List<Hike>> GetAllHike()
        {
            return db.Table<Hike>().ToListAsync();
        }

        public Task<int> UpdateHike(Hike hike)
        {
            return db.UpdateAsync(hike);
        }

        public Task<int> DeleteHike(Hike hike)
        {
            return db.DeleteAsync(hike);
        }
    }
}
