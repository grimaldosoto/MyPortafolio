using System;
using System.Collections.Generic;

namespace Catalog.Domain.Entities
{
    public partial class Menu : BaseEntity
    {
        public Menu()
        {
            MenuRoles = new HashSet<MenuRole>();
        }

        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public int? FatherId { get; set; }

        public virtual ICollection<MenuRole> MenuRoles { get; set; }
    }
}
