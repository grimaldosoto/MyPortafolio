namespace Catalog.Application.Dtos.Technology.Response
{
    public class TechnologyResponseDto
    {
        public int TechnologyId { get; set; }
        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
