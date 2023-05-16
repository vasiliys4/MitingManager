using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model.Operations
{
    internal interface IShow
    {
        void ShowAll();
        List<Meeting> ShowMeeting(DateOnly dateOnly, List<Meeting> MeetingList);
    }
}
