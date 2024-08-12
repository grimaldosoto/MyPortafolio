namespace Catalog.Domain.Entities
{
    public partial class Technology : BaseEntity
    {
        public Technology()
        {
            TechStackApps = new HashSet<TechStackApp>();
        }

        public string Name { get; set; } = null!;
        public string? Version { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TechStackApp> TechStackApps { get; set; }
    }
}
