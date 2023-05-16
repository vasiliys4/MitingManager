using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitingManager.Model.Operations
{
    internal interface IMeetingRemove
    {
        public void Remove(List<Meeting> MeeteingList);
    }
}
