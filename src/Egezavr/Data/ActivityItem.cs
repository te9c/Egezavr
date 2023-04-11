using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egezavr.Data
{
    [Table("activitydb")]
    public class ActivityItem
    {
        [PrimaryKey, AutoIncrement, Column("Activites")]
        public int ID { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
