using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Eventmi.Infrastructure.Data.Common;
using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Core.Services
{
    /// <summary>
    /// Service for events control
    /// </summary>
    public class EventService : IEventService
    {
        /// <summary>
        /// Access to Database
        /// </summary>
        private readonly IRepository repo;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="repo">Access to Database</param>
        public EventService(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Add event
        /// </summary>
        /// <param name="model">Event data</param>
        /// <returns></returns>
        public async Task AddAsync(EventDetailsModel model)
        {
            Event entity = new Event()
            {
                Name = model.Name,
                Start = model.Start,
                End = model.End,
                Place = model.Place
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            await repo.DeleteAsync<Event>(id);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Event update
        /// </summary>
        /// <param name="model">Event data</param>
        /// <returns></returns>
        public async Task UpdateAsync(EventModel model)
        {
            var entity = await repo.GetByIdAsync<Event>(model.Id);
            if (entity == null)
            {
                throw new ArgumentException("Invalid ID!", nameof(model.Id));
            }

            entity.Name = model.Name;
            entity.Start = model.Start;
            entity.End = model.End;
            entity.Place = model.Place;

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// All events
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Event>()
                .Select(e => new EventModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    Place = e.Place
                })
                .OrderBy(e => e.Start)
                .ToListAsync();
        }

        /// <summary>
        /// Get event
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns></returns>
        public async Task<EventDetailsModel> GetEventAsync(int id)
        {
            var entity = await repo.GetByIdAsync<Event>(id);
            if (entity == null)
            {
                throw new ArgumentException("Invalid ID!", nameof(id));
            }

            return new EventDetailsModel()
            {
                Name = entity.Name,
                Start = entity.Start,
                End = entity.End,
                Place = entity.Place
            };
        }
    }
}