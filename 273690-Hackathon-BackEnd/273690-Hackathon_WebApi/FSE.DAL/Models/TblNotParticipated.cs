using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblNotParticipated
    {
        public int Id { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public string BeneficiaryName { get; set; }
        public int EmployeeId { get; set; }
        public int? BaseLocationId { get; set; }
        public int? UserCategoryId { get; set; }
        public bool IsReminderSent { get; set; }

        public virtual TblBaseLocation BaseLocation { get; set; }
        public virtual TblUserCategory UserCategory { get; set; }
    }
}
