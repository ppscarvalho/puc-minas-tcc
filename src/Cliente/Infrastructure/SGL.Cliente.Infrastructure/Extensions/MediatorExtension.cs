
using SGL.Cliente.Infrastructure.DbContexts;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Domain;

namespace SGL.Cliente.Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublishEvent(this IMediatorHandler mediator, ClienteDbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvent());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
