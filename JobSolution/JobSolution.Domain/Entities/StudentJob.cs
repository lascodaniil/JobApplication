

namespace JobSolution.Domain.Entities
{
    public class StudentJob : BaseEntity
    {
        public int StudentId { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public Student Student { get; set; }
    }
}
