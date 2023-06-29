using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SGL.Cliente.Infrastructure.Extensions;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Data;
using SGL.Resource.Domain;
using SGL.Resource.Messagens;

namespace SGL.Cliente.Infrastructure.DbContexts
{
    public class ClienteDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public DbSet<Core.Domain.Entities.Cliente> Cliente { get; set; }

        public ClienteDbContext(DbContextOptions<ClienteDbContext> options, IMediatorHandler mediatorHandler)
                : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteDbContext).Assembly);

            foreach (var type in modelBuilder.Model.GetEntityTypes().Where(e => typeof(Entity).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder
                    .Entity(type.ClrType)
                    .HasKey("Id");

                modelBuilder
                    .Entity(type.ClrType)
                    .Property<DateTime>("CriadoEm")
                    .IsRequired();

                modelBuilder
                    .Entity(type.ClrType)
                    .Property<DateTime?>("ModificadoEm");
            }
        }
        private void SetDefaultValues()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("ModificadoEm").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("CriadoEm").IsModified = false;
            }
        }

        public async Task<bool> Commit()
        {
            SetDefaultValues();
            var sucesso = await base.SaveChangesAsync() > 0;
            if (sucesso) await _mediatorHandler.PublishEvent(this);

            return sucesso;
        }
    }
}
