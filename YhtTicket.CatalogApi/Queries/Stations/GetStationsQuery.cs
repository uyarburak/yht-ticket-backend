using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using YhtTicket.Common.EybisClient;
using YhtTicket.Common.Infrastructure.Exceptions;

namespace YhtTicket.CatalogApi.Queries.Stations
{
    public class GetStationsQuery : IRequest<List<GetStationsResponse>>
    {
    }

    public class GetStationsQueryHandler : IRequestHandler<GetStationsQuery, List<GetStationsResponse>>
    {
        private readonly ITcddService _tcddService;

        public GetStationsQueryHandler(ITcddService tcddService)
        {
            _tcddService = tcddService;
        }

        public async Task<List<GetStationsResponse>> Handle(GetStationsQuery request, CancellationToken cancellationToken)
        {
            var stations = await GetStationsFromTcdd(cancellationToken);

            return stations;
        }

        private async Task<List<GetStationsResponse>> GetStationsFromTcdd(CancellationToken cancellationToken)
        {
            try
            {
                var stations = await _tcddService.GetStationsAsync(cancellationToken);
                var response = stations.Select(x => new GetStationsResponse
                {
                    Id = x.IstasyonId,
                    Code = x.IstasyonKodu,
                    Name = x.IstasyonAdi
                }).OrderBy(x => x.Name).ToList();

                return response;
            }
            catch (System.Exception)
            {
                throw new ApiException(HttpStatusCode.BadGateway, "TCDD_ERROR", "Bilinmeyen Hata");
            }
        }
    }
}
