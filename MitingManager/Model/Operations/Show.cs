using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model.Operations
{
    internal class Show : IShow
    {        
        private List<Meeting> meetings;
        public Show(List<Meeting> _meetings) 
        {
            meetings = _meetings;
        }
        public void ShowAll()
        {
            for (var i = 0; i < meetings.Count; i++)
            {
                Console.WriteLine($"{i + 1} описание: {meetings[i].Description}\n дата и время начала: {meetings[i].MeetingStart} дата и время окончания: {meetings[i].MeetingEnd}\n");
            }
        }
        public List<Meeting> ShowMeeting(DateOnly dateOnly, List<Meeting> MeetingList)
        {
            for (var i = 0; i < meetings.Count; i++)
            {
                if (meetings[i].MeetingStart.Month == dateOnly.Month && meetings[i].MeetingStart.Day == dateOnly.Day)
                {
                    Console.WriteLine($"{i + 1} описание: {meetings[i].Description}\n дата и время начала: {meetings[i].MeetingStart} дата и время окончания: {meetings[i].MeetingEnd}\n");
                    MeetingList.Add(meetings[i]);
                }
            }
            return MeetingList;
        }
    }
}
