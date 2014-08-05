using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Infrastructure.Data.MainModule.Models
{
    public partial class TemplateContext : DbContext
    {
        static TemplateContext()
        {
            Database.SetInitializer<TemplateContext>(null);
        }

        public TemplateContext()
            : base("Name=TemplateContext")
        {
        }

        public DbSet<Domain.Entities.Template> Templates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new TemplateMap());
        }
    }
}
