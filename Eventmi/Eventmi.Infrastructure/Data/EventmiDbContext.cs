using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Infrastructure.Data
{
    /// <summary>
    /// Контекст, описващ базата данни
    /// </summary>
    public class EventmiDbContext : DbContext
    {
        /// <summary>
        /// Create context without options
        /// </summary>
        public EventmiDbContext()
        {

        }

        /// <summary>
        /// Create context with options
        /// </summary>
        /// <param name="options">Context options</param>
        public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
        : base(options)
        {

        }

        /// <summary>
        /// Table with events
        /// </summary>
        public DbSet<Event> Events { get; set; } = null!;

    }
}
