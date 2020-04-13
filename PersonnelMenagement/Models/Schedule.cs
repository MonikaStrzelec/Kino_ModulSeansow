using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelMenagement.Models
{
    public class Schedule
    {
        long id;
        long userId;
        long taskId;
        DateTime dateFrom;
        DateTime dateTo;
        ScheduleStatus statusId;
    }
}
