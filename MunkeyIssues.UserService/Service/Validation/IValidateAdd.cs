using System.Collections.Generic;

namespace MunkeyIssues.UserService.Service.Validation
{
    public interface IValidateAdd<in TType>
    {
        /// <summary>
        /// Validates whether or not the type can be added to the database
        /// </summary>
        /// <param name="type">The type to validate</param>
        /// <returns>The list of validation errors</returns>
        IList<string> ValidateAdd(TType type);
    }
}