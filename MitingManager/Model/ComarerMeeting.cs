using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model
{
    internal class ComarerMeeting : IComparer<Meeting>
    {
        public int Compare(Meeting x, Meeting y)
        {
            if (x.MeetingStart.Month != y.MeetingStart.Month)
            {
                return x.MeetingStart.Month - y.MeetingStart.Month;
            }
            return x.MeetingStart.Day - y.MeetingStart.Day;
        }
    }
}
