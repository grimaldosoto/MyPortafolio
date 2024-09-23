using System;
using System.Collections.Generic;

namespace Catalog.Domain.Entities
{
    public partial class MenuRole : BaseEntity
    {
        public int? RoleId { get; set; }
        public int? MenuId { get; set; }

        public virtual Menu? Menu { get; set; }
        public virtual Role? Role { get; set; }
    }
}
