using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class JobForViewDTO
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Employer { get; set; }
        public string Contact { get; set; }
        public string  Category { get; set; }
        public string Salary { get; set; }
        public DateTime? PublishedOn { get; set; }
        public DateTime? FinishedOn { get; set; }
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public string TypeJob { get; set; }

    }
}
