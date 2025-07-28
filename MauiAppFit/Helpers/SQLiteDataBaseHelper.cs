using MauiAppFit.Models;
using SQLite;

namespace MauiAppFit.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteConnection _db;

        public SQLiteDataBaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Atividade>().Wait();
        }

        public Task<List<Atividade>> GetAllRows()
        {
            return _db.Table<Atividade>().OrderByDescending(i => i.Id).ToListAsync();
        }
        
        public Task<Atividade> GetById(int id)
        {
            return _db.Table<Atividade>().FirstAsync(i => i.Id == id);
        }
    }
}
