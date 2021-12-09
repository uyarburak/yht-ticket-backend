using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YhtTicket.Common.Infrastructure.Services;
using YhtTicket.Common.MassTransit.Producer;
using YhtTicket.Common.Models.Alert;

namespace YhtTicket.AlertApi.Commands.Alerts
{
    public class CreateAlertsCommand : List<CreateAlertRequest>, IRequest<List<string>>
    {
    }

    public class GetSchedulesQueryHandler : IRequestHandler<CreateAlertsCommand, List<string>>
    {
        private readonly IMessageProducer _messageProducer;
        private readonly IUserService _userService;

        public GetSchedulesQueryHandler(IMessageProducer messageProducer, IUserService userService)
        {
            _messageProducer = messageProducer;
            _userService = userService;
        }

        public async Task<List<string>> Handle(CreateAlertsCommand request, CancellationToken cancellationToken)
        {
            var list = new List<string>();

            foreach (var alert in request)
            {
                var id = Guid.NewGuid().ToString();
                await _messageProducer.PublishAsync(new CreateAlertCommand
                {
                    Id = id,
                    ScheduleId = alert.ScheduleId,
                    DepartureStationName = alert.DepartureStationName,
                    DestinationStationName = alert.DestinationStationName,
                    StartDate = alert.StartDate,
                    EndDate = alert.EndDate,
                    Wagons = alert.Wagons,
                    Username = _userService.GetCurrentUsername(),
                });

                list.Add(id);
            }

            return list;
        }
    }
}
