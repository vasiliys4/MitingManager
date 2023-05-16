using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model.Operations
{
    internal class MeetingRemove : IMeetingRemove
    {
        public void Remove(List<Meeting> meetings)
        {
            Console.WriteLine($"Выберите запись которую нужно удалить:");
            int number = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < meetings.Count; i++)
            {
                i = number - 1;
                if (i > meetings.Count)
                {
                    Remove(meetings);
                }
                else if (i < 0)
                {
                    Remove(meetings);

                }
                else
                {
                    meetings.RemoveAt(i);
                }
            }
        }
    }
}
