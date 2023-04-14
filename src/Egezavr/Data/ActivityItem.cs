using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egezavr.Data
{
    [Table("activityitem")]
    public class ActivityItem
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int ID { get; set; }

        [Column("day")]
        public Constants.Days Day { get; set; }

        [Column("examindex")]
        public int ExamOptionIndex { get; set; }

        [Column("timefrom")]
        public TimeSpan TimeFrom { get; set; }

        [Column("timeto")]
        public TimeSpan TimeTo { get; set; }
    }
}
