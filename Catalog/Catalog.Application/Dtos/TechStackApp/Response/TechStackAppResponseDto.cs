using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Dtos.TechStackApp.Response
{
    public class TechStackAppResponseDto
    {
        public int TechStackAppId { get; set; }
        public string? NameApp { get; set; }
        public DateTime ReleaseDateApp { get; set; }
        public string? VersionApp { get; set; }
        public string? RepositoryLinkApp { get; set; }
        public string? LiveLinkApp { get; set; }
        public string? NameTechnology { get; set; }
        public string? VersionTechnology { get; set; }

    }
}
