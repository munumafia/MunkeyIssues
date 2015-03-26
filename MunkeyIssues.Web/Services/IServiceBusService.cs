using System.Threading.Tasks;

namespace MunkeyIssues.Web.Services
{
    public interface IServiceBusService
    {
        Task<TResponse> ExecuteRequestAsync<TRequest, TResponse>(TRequest request) 
            where TRequest : class 
            where TResponse : class;

        TResponse ExecuteRequest<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class;
    }
}