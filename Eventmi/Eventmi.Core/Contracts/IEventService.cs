using Eventmi.Core.Models;

namespace Eventmi.Core.Contracts
{
    /// <summary>
    /// Service for control of events
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Add event
        /// </summary>
        /// <param name="model">Event data</param>
        /// <returns></returns>
        Task AddAsync(EventDetailsModel model);

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Event update
        /// </summary>
        /// <param name="model">Event data</param>
        /// <returns></returns>
        Task UpdateAsync(EventModel model);

        /// <summary>
        /// All events
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventModel>> GetAllAsync();

        /// <summary>
        /// Get event
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns></returns>
        Task<EventDetailsModel> GetEventAsync(int id);
    }
}