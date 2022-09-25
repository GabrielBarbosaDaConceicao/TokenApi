using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TokenApi.Authentication;

namespace TokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string GetAnonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string GetAuthenticated() => $"Autenticado - {User?.Identity?.Name} ";

        [HttpGet]
        [Route("user")]
        [Authorize(Roles = UserRoles.User)]
        public string GetUser() => "User";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = UserRoles.Admin)]
        public string GetAdmin() => "Admin";

    }
}
