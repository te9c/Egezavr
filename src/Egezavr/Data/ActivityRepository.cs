using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egezavr.Data
{
    public class ActivityRepository
    {
        private SQLiteAsyncConnection Database;

        public ActivityRepository() { }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<ActivityItem>();
        }

        public async Task<List<ActivityItem>> GetAllActivities()
        {
            await Init();
            return await Database.Table<ActivityItem>().ToListAsync();
        }

        public async Task<int> SaveItemAsync(ActivityItem item)
        {
            await Init();
            if (item.ID >= 1 && item.ID <= 7)
                return await Database.UpdateAsync(item);
            return 0;
        }
        public async Task<int> InsertItemAsync(ActivityItem item)
        {
            await Init();
            if (item.ID != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }
    }
}
