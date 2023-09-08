namespace Codility2.Models
{
    public class ApplicantJob
    {
        public Guid ApplicantId { get; set; }
        public Guid JobId { get; set; }

        public Applicant? Applicant { get; set; }
        public Job? Job { get; set; }
    }
}
