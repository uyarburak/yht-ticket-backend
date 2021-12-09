using System;
using System.Collections.Generic;

namespace YhtTicket.AlertApi.Commands.Alerts
{
    public class CreateAlertRequest
    {
        public long ScheduleId { get; set; }
        public string DepartureStationName { get; set; }
        public string DestinationStationName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> Wagons { get; set; }
    }
}
