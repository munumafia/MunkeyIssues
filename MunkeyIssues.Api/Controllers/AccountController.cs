using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MunkeyIssues.Api.Models;
using MunkeyIssues.Api.Services.Users;
using MunkeyIssues.Core.Messaging.Users.Register;

namespace MunkeyIssues.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IUserService _UserService;
        private readonly IMappingEngine _Mapper;

        public AccountController(IUserService userService, IMappingEngine mapper)
        {
            _UserService = userService;
            _Mapper = mapper;
        }

        [Route("register")]
        public Task<RegisterUserResponse> Register(RegisterViewModel model)
        {
            var request = _Mapper.Map<RegisterUserRequest>(model);
            return _UserService.Register(request);
        }
    }
}