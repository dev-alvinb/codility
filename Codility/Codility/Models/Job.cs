using System;

namespace Codility.Models
{
    public class Job
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
