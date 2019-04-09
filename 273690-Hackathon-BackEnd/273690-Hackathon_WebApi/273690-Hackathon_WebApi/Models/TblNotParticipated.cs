using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblNotParticipated
    {
        public int Id { get; set; }
        public string EventId { get; set; }
        public int EmployeeId { get; set; }
        public int? UserCategoryId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? BaseLocationId { get; set; }
        public string Designation { get; set; }

        public virtual TblBaseLocation BaseLocation { get; set; }
        public virtual TblBusinessUnit BusinessUnit { get; set; }
        public virtual TblUserCategory UserCategory { get; set; }
    }
}
