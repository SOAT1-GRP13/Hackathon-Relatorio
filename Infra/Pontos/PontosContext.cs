using Domain.Pontos;
using Domain.Base.Data;
using System.Reflection;
using Domain.Base.Messages;
using Microsoft.EntityFrameworkCore;

namespace Infra.Pontos
{
    public class PontosContext : DbContext, IUnitOfWork
    {
        public PontosContext(DbContextOptions<PontosContext> options) : base(options)
        {
        }

        public DbSet<Ponto> Pontos => Set<Ponto>();

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<Event>();

            var types = modelBuilder.Model.GetEntityTypes().Select(t => t.ClrType).ToHashSet();

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                t => t.GetInterfaces()
                .Any(i => i.IsGenericType
                && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)
                && types.Contains(i.GenericTypeArguments[0]))
                );

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
