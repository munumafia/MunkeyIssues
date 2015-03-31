using System.Collections.Generic;

namespace MunkeyIssues.UserService.Service.Validation
{
    public interface IValidateUpdate<in TType>
    {
        /// <summary>
        /// Validates whether or not the type can be updated in the database
        /// </summary>
        /// <param name="type">The type to validate</param>
        /// <returns>List of validation errors</returns>
        IList<string> ValidateUpdate(TType type);
    }
}
