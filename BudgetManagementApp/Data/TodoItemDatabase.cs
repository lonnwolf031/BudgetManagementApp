using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using BudgetManagementApp.Models;

namespace BudgetManagementApp.Data
{
    public class BudgetItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<BudgetItemDatabase> Instance = new AsyncLazy<BudgetItemDatabase>(async () =>
        {
            var instance = new BudgetItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<BudgetItem>();
            return instance;
        });

        public BudgetItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<BudgetItem>> GetItemsAsync()
        {
            return Database.Table<BudgetItem>().ToListAsync();
        }

        public Task<List<BudgetItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<BudgetItem>("SELECT * FROM [BudgetItem] WHERE [Done] = 0");
        }

        public Task<BudgetItem> GetItemAsync(int id)
        {
            return Database.Table<BudgetItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(BudgetItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(BudgetItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
