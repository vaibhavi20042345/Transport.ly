using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.ly
{
    interface IScheduleRepository
    {
        IList<Schedule> GetSchedules();
    }
}
