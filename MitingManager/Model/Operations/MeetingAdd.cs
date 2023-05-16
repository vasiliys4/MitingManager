using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model.Operations
{
    public class MeetingAdd : IMeetingAdd
    {
        private List<Meeting> meetings;
        public MeetingAdd(List<Meeting> _meetings) 
        {
            meetings = _meetings;
        }
        
        private Meeting Write(Meeting Meeting)
        {
            Console.WriteLine("Введите описание встречи");
            Meeting.Description = Console.ReadLine();
            Console.WriteLine("Введите дату встречи\nформат MM.dd");
            AddDate(Meeting);
            DateTime date = DateTime.Now;
            if (Meeting.MeetingStart < date)
            {
                Console.WriteLine("Встречу нельзя назначить на прошлое");
                AddDate(Meeting);
            }         
            return Meeting;
        }
        private DateTime AddDate(Meeting Meeting)
        {
            var Date = Console.ReadLine();
            string[] date = Date.Split('.');
            Console.WriteLine("Введите время начала встречи\nформат hh:mm");
            var Time = Console.ReadLine();
            string[] timeStart = Time.Split(':');
            Meeting.MeetingStart = new(2023, int.Parse(date[0]), int.Parse(date[1]), int.Parse(timeStart[0]), int.Parse(timeStart[1]), 00);
            var tmp = true;
            while (tmp) 
            {
                Console.WriteLine("Введите время окончания встречи\nформат hh:mm");
                var TimeEnd = Console.ReadLine();
                var timeEnd = TimeEnd.Split(':');
                Meeting.MeetingEnd = new(2023, int.Parse(date[0]), int.Parse(date[1]), int.Parse(timeEnd[0]), int.Parse(timeEnd[1]), 00);
                if (Meeting.MeetingStart.Hour < Meeting.MeetingEnd.Hour)
                {
                    tmp = false;
                    break;
                }
                else if (Meeting.MeetingStart.Hour == Meeting.MeetingEnd.Hour && Meeting.MeetingStart.Minute < Meeting.MeetingEnd.Minute)
                {
                    tmp = false;
                    break;
                }
                Console.WriteLine();
            }
            return Meeting.MeetingStart;
        }
        public Meeting ValidationData()
        {
            Meeting Meeting = new();
            Write(Meeting);
            if (meetings.Count == 0)
            {
                return Meeting;                
            }
            else
            {
                var tmp = true;
                while (tmp)
                {                    
                    tmp = false;
                    for (int i = 0; i < meetings.Count; i++)
                    {
                        if (Meeting.MeetingStart.Month == meetings[i].MeetingStart.Month && Meeting.MeetingStart.Day == meetings[i].MeetingStart.Day)
                        {
                            if (Meeting.MeetingStart.Hour < meetings[i].MeetingStart.Hour && Meeting.MeetingEnd.Hour > meetings[i].MeetingStart.Hour)
                            {
                                Console.WriteLine("Встречи пересекаются");
                                AddDate(Meeting);
                                tmp = true;
                                break;
                            }
                            if (Meeting.MeetingEnd.Hour > meetings[i].MeetingStart.Hour && Meeting.MeetingStart.Hour < meetings[i].MeetingEnd.Hour)
                            {
                                Console.WriteLine("Встречи пересекаются");
                                AddDate(Meeting);
                                tmp = true;
                                break;
                            }
                            if (Meeting.MeetingStart.Hour == meetings[i].MeetingEnd.Hour || Meeting.MeetingEnd.Hour == meetings[i].MeetingStart.Hour)
                            {
                                if (Meeting.MeetingStart.Minute < meetings[i].MeetingStart.Minute && Meeting.MeetingEnd.Minute > meetings[i].MeetingStart.Minute)
                                {
                                    Console.WriteLine("Встречи пересекаются");
                                    AddDate(Meeting);
                                    tmp = true;
                                    break;
                                }
                                if (Meeting.MeetingEnd.Minute > meetings[i].MeetingStart.Minute && Meeting.MeetingStart.Minute < meetings[i].MeetingEnd.Minute)
                                {
                                    Console.WriteLine("Встречи пересекаются");
                                    AddDate(Meeting);
                                    tmp = true;
                                    break;
                                }
                            }
                        }
                    }               
                }
            }
            //meetings.Add(Meeting);
            meetings.Sort(new ComarerMeeting());
            return Meeting;
        }        
    }
}
