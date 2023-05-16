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
        public void Export(List<Meeting> MeetingList)
        {
            var path = @"note.txt";
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(MeetingList);
            }
        }
    }
}
