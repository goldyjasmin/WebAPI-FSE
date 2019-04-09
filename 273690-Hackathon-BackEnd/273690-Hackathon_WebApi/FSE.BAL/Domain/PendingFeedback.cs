using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.BAL.Domain
{
    public class PendingFeedback
    {
        public int EventPrimaryId { get; set; }
        public string EventId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string BU { get; set; }
        public string EventName { get; set; }

        public int UserTypeId { get; set; }
        public string UserType { get; set; }
    }
    
}
