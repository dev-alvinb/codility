using System.ComponentModel.DataAnnotations.Schema;

namespace Codility2.Models
{
    public class Applicant
    {
        public Guid Id { get; set; } = new Guid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<ApplicantJob>? ApplicantJobs { get; set; }
    }
}
