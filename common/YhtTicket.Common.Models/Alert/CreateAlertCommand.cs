using System;
using System.Collections.Generic;

namespace YhtTicket.Common.Models.Alert
{
    public class CreateAlertCommand
    {
        public string Id { get; set; }
        public long ScheduleId { get; set; }
        public string DepartureStationName { get; set; }
        public string DestinationStationName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> Wagons { get; set; }
        public string Username { get; set; }
    }
}
