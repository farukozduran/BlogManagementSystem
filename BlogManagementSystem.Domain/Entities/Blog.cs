using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagementSystem.Domain.Entities
{
    public class Blog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Foreign Keys
        public int CategoryId { get; set; }
        public Guid UserId { get; set; }

        // Navigation
        public Category? Category { get; set; }
        public User? User { get; set; }
    }
}
