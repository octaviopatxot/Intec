using System;
using System.Collections.Generic;

namespace IntecWeb.Models
{
    public partial class Subject
    {
        public Subject()
        {
            StudentSubjectCross = new HashSet<StudentSubjectCross>();
        }

        public Guid Id { get; set; }
        public int Seq { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public short Credits { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<StudentSubjectCross> StudentSubjectCross { get; set; }
    }
}
