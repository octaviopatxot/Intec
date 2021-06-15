using System;
using System.Collections.Generic;

namespace IntecWeb.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentSubjectCross = new HashSet<StudentSubjectCross>();
        }

        public Guid Id { get; set; }
        public int Seq { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<StudentSubjectCross> StudentSubjectCross { get; set; }
        public int? StudentId { get; internal set; }
    }
}
