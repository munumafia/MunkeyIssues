using System.Threading.Tasks;
using MunkeyIssues.Core.Messaging.Issues.Category;

namespace MunkeyIssues.Api.Services.Categories
{
    public interface ICategoryService
    {
        /// <summary>
        /// Creates a new category asynchrously
        /// </summary>
        /// <param name="request">The request to send across the ESB to create the category</param>
        /// <returns>The response from the microservice</returns>
        Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request);

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="request">The request to send across the ESB to create the category</param>
        /// <returns>The response from the microservice</returns>
        CreateCategoryResponse CreateCategory(CreateCategoryRequest request);

        /// <summary>
        /// Retrieves an existing category asynchrously
        /// </summary>
        /// <param name="request">The request with the information about what category to retrieve</param>
        /// <returns>The response with the category</returns>
        Task<GetCategoryResponse> GetCategoryAsync(GetCategoryRequest request);

        /// <summary>
        /// Retrieves an existing category
        /// </summary>
        /// <param name="request">The request with the information about what category to retrieve</param>
        /// <returns>The response with the category</returns>
        GetCategoryResponse GetCategory(GetCategoryRequest request);
    }
}
