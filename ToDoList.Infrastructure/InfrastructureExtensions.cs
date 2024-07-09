using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=app.db"));

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (dbContext.Database.EnsureCreated())
            {
                dbContext.Database.Migrate();
                AddSeedData(dbContext);
            }
            return services;
        }

        private static void AddSeedData(AppDbContext dbContext)
        {
            dbContext.ToDoRecords.AddRange(
                new ToDoRecord
                {
                    Id = 1,
                    Title = "Buy coke",
                    CreatedOn = DateTime.Now.AddDays(-1),
                    DueDate = DateTime.Now.AddDays(2),
                    FinishedAt = DateTime.MinValue,
                    Description = "Diet coke only",
                    State = ToDoState.Created,
                    IsDeleted = false
                },
                new ToDoRecord
                {
                    Id = 2,
                    Title = "Homework",
                    CreatedOn = DateTime.Now.AddDays(-3),
                    DueDate = DateTime.Now.AddDays(1),
                    FinishedAt = DateTime.Now.AddDays(-1),
                    Description = "Finish it as soon as possible",
                    State = ToDoState.Finished,
                    IsDeleted = false
                },
                new ToDoRecord
                {
                    Id = 3,
                    Title = "Feed cat",
                    CreatedOn = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(1),
                    FinishedAt = DateTime.MinValue,
                    Description = "Use fish meat this time",
                    State = ToDoState.Created,
                    IsDeleted = false
                }
            );

            dbContext.SaveChanges();
        }
    }
}
