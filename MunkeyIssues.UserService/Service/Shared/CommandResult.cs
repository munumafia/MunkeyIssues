using System.Collections.Generic;

namespace MunkeyIssues.UserService.Service.Shared
{
    public class CommandResult<TEntity>
    {
        /// <summary>
        /// The entity that is being processed
        /// </summary>
        public TEntity Entity { get; set; }

        /// <summary>
        /// The number of rows in the database that were affected
        /// </summary>
        public int RowsAffected { get; set; }

        /// <summary>
        /// Any validation errors that were encountered
        /// </summary>
        public IList<string> ValidationErrors { get; set; } 
    }
}
