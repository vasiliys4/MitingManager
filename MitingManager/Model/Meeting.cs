using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model
{
    public class Meeting
    {        
        public DateTime MeetingStart { get; set; }
        public DateTime MeetingEnd { get; set; }
        public string? Description { get; set; }
    }
}
