using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Domain.Base.Communication.Mediator;
using Microsoft.Extensions.Caching.Memory;
using Domain.Base.Messages.CommonMessages.Notifications;

namespace API.Controllers
{
    [ApiController]
    [Route("Notificacao")]
    [SwaggerTag("Endpoints relacionados a notificacao")]
    public class RelatorioController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMemoryCache _memoryCache;

        public RelatorioController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IMemoryCache memoryCache) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _memoryCache = memoryCache;
        }
    }
}
