using System;
using System.Collections.Generic;

namespace Catalog.Domain.Entities
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            MenuRoles = new HashSet<MenuRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public string? Description { get; set; }

        public virtual ICollection<MenuRole> MenuRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
