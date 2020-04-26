using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class JobGridRowDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Employer { get; set; }
        public string City { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime FinishOn { get; set; }
        public string Base64Photo { get; set; }
        public string Contact { get; set; }
    }
}
