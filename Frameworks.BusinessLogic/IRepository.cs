namespace Tui.Frameworks.BusinessLogic
{
    using System.Collections.Generic;
	
    /// <summary>
    /// Base interface for all repositories
    /// </summary>
    public interface IRepository<T> where T : IAggregateRoot
    {
		/// <summary>
        /// Retrieve all entities
        /// </summary>
        IEnumerable<T> GetAll();
    }
}
