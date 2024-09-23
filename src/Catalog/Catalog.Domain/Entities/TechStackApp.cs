namespace Catalog.Domain.Entities
{
    public partial class TechStackApp : BaseEntity
    {
        public int AppId { get; set; }
        public int TechnologyId { get; set; }
        public virtual App App { get; set; } = null!;
        public virtual Technology Technology { get; set; } = null!;
    }
}
