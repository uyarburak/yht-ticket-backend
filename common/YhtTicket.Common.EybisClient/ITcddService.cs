using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YhtTicket.Common.EybisClient.Models;

namespace YhtTicket.Common.EybisClient
{
    public interface ITcddService
    {
        Task<List<YhtStationInfo>> GetStationsAsync(CancellationToken cancellationToken = default);
        Task<List<YhtScheduleInfo>> GetSchedulesAsync(string departure, string destination, DateTime departureDate, CancellationToken cancellationToken = default);
    }
}
