using System;
using System.Collections.Generic;

namespace IntecWeb.Models
{
    public partial class StudentSubjectCross
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public short Grade { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
