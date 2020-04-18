using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelMenagement.Models
{
    public class Schedule
    {
        public long id;
        public long userId;
        public long taskId;
        public DateTime dateFrom;
        public DateTime dateTo;
        public ScheduleStatus statusId;
    }
}
