﻿namespace Catalog.Domain.Entities
{
    public partial class UserRole : BaseEntity
    {
        public int? RoleId { get; set; }
        public int? UserId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
