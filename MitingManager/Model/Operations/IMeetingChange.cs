using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model.Operations
{
    internal interface IMeetingChange
    {
        public Meeting Change(int nomer, List<Meeting> meetings, Meeting meeting);
    }
}
