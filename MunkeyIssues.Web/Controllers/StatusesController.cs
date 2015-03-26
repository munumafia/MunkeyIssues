using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MunkeyIssues.Core.Messaging.Issues.Status;
using MunkeyIssues.Web.Models;
using MunkeyIssues.Web.ResponseMappers;
using MunkeyIssues.Web.Services.Statuses;

namespace MunkeyIssues.Web.Controllers
{
    public class StatusesController : ApiController
    {
        private readonly IMappingEngine _Mapper;
        private readonly IResponseMapper _ResponseMapper;
        private readonly IStatusService _StatusService;

        public StatusesController(IMappingEngine mapper, IResponseMapper responseMapper, IStatusService statusService)
        {
            _Mapper = mapper;
            _ResponseMapper = responseMapper;
            _StatusService = statusService;
        }

        public Task<HttpResponseMessage> Get(int id)
        {
            var request = new GetStatusRequest { StatusId = id };
            return _StatusService.GetStatusAsync(request).ContinueWith(resp =>
            {
                var message = resp.Result;
                var viewModel = _Mapper.Map<StatusViewModel>(message.Status);
                return _ResponseMapper.ForGet(Request, viewModel, message.Result);
            });
        }

        public Task<HttpResponseMessage> Post(StatusViewModel model)
        {
            var request = new CreateStatusRequest { Status = _Mapper.Map<Status>(model) };
            return _StatusService.CreateStatusAsync(request).ContinueWith(resp =>
            {
                var message = resp.Result;
                var viewModel = _Mapper.Map<StatusViewModel>(message.Status);
                return _ResponseMapper.ForCreate(Request, viewModel, message.Result);
            });
        }
    }
}