using System;
using System.Collections.Generic;

namespace YhtTicket.CatalogApi.Queries.Schedules
{
    public class GetSchedulesResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<WagonType> WagonTypes { get; set; }
    }

    public class WagonType
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int[] Wagons { get; set; }
    }
}
