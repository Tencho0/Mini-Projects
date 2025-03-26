﻿namespace MicrosoftIdentity.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using MicrosoftIdentity.Database;

    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
