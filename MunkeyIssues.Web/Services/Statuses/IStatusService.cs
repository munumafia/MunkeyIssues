using System.Threading.Tasks;
using MunkeyIssues.Core.Messaging.Issues.Status;

namespace MunkeyIssues.Web.Services.Statuses
{
    public interface IStatusService
    {
        Task<CreateStatusResponse> CreateStatusAsync(CreateStatusRequest request);
        CreateStatusResponse CreateStatus(CreateStatusRequest request);
        Task<GetStatusResponse> GetStatusAsync(GetStatusRequest request);
        GetStatusResponse GetStatus(GetStatusRequest request);
    }
}