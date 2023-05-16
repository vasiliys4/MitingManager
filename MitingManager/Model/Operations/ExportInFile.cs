using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MitingManager.Model.Operations
{
    internal class ExportInFile
    {
        public async void Export(List<Meeting> MeetingList)
        {
            var path = @"note.txt";
            StreamWriter writer = new StreamWriter(path, true);
                foreach (Meeting meeting in MeetingList)
                {
                    writer.WriteLine(meeting.Description);
                    writer.WriteLine(meeting.MeetingStart);
                    writer.WriteLine(meeting.MeetingEnd);
                }
            writer.Close();
        }
    }
}
