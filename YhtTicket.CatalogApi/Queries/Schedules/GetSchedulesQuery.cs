using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using YhtTicket.Common.EybisClient;

namespace YhtTicket.CatalogApi.Queries.Schedules
{
    public class GetSchedulesQuery : IRequest<List<GetSchedulesResponse>>
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime Day { get; set; }
    }

    public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, List<GetSchedulesResponse>>
    {
        private readonly ITcddService _tcddService;

        public GetSchedulesQueryHandler(ITcddService tcddService)
        {
            _tcddService = tcddService;
        }

        public async Task<List<GetSchedulesResponse>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
        {
            var schedules = await _tcddService.GetSchedulesAsync(request.Departure, request.Destination, request.Day, cancellationToken);

            return schedules.Select(x => new GetSchedulesResponse
            {
                    Id = x.SeferId,
                    Name = x.TrenAdi.Trim(),
                    Type = x.TrenTipi,
                    StartDate = DateTime.ParseExact(x.BinisTarih, "MMM d, yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact(x.InisTarih, "MMM d, yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    WagonTypes = x.VagonTipleriBosYerUcret.Select(w => new WagonType
                    {
                        Name = Regex.Replace(w.VagonTip, @"\s+", " "),
                        Price = w.StandartBiletFiyati,
                        Wagons = w.VagonListesi.Select(x => x.VagonSiraNo).ToArray()
                    })
                })
                .OrderBy(x => x.StartDate)
                .ToList();
        }
    }
}
