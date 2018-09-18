namespace Tui.Frameworks.BusinessLogic
{
    using System;
    /// <summary>
    /// Base class for the entity DDD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Entity<T>
    {
        /// <summary>
        /// The identifier of the entity
        /// </summary>
        public T Id { get; set; }
    }
}
