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
        private SQLiteConnection Database;

        public ActivityRepository() { }

        void Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            Database.CreateTable<ActivityItem>();
        }

        public List<ActivityItem> GetActivities()
        {
            Init();
            return Database.Table<ActivityItem>().ToList();
        }
        public ActivityItem GetActivity(int id)
        {
            Init();
            return Database.Table<ActivityItem>().Where(i => i.ID == id).FirstOrDefault();
        }

        public int SaveActivity(ActivityItem item)
        {
            Init();

            if (item.ID != 0)
                return Database.Update(item);
            else
                return Database.Insert(item);
        }

        public int DeleteActivity(ActivityItem item)
        {
            Init();
            return Database.Delete(item);
        }
    }
}
