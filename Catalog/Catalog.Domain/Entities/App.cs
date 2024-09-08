namespace Catalog.Domain.Entities
{
    public partial class App : BaseEntity
    {
        public App()
        {
            TechStackApps = new HashSet<TechStackApp>();
        }

        public string Name { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string Version { get; set; } = null!;
        public string? RepositoryLink { get; set; }
        public string? LiveLink { get; set; }

        public virtual ICollection<TechStackApp> TechStackApps { get; set; }
    }
}
