using System.ComponentModel.DataAnnotations.Schema;

namespace Codility2.Models
{
    public class Job
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ApplicantJob>? ApplicantJobs { get; set; }
    }
}
