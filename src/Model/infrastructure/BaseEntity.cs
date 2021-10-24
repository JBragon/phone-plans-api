using System;

namespace JBragon.Models.infrastructure
{
    public abstract class BaseEntity<TPrimarykey>
    {
        public TPrimarykey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
