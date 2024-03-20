using API.Controllers;
using Domain.Base.Communication.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Domain.Base.Messages.CommonMessages.Notifications;

namespace API.Tests.Controllers
{
    public class RelatorioControllerTests
    {
        

        private ClaimsPrincipal ClaimsPrincipal()
        {
            var fakeUserId = Guid.NewGuid().ToString();
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, fakeUserId) };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            return claimsPrincipal;
        }


    }
}
