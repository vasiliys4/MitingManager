using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model.Operations
{
    internal class MeetingChange : IMeetingChange
    {
        public Meeting Change(int nomer, List<Meeting> meetings, Meeting meeting)
        {
            meetings.RemoveAt(nomer - 1);
            meetings.Insert(nomer -1, meeting);
            return meetings[nomer - 1];
        }
    }
}
