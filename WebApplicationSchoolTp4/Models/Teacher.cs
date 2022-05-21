using System.ComponentModel.DataAnnotations;

namespace WebApplicationSchoolTp4.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int SchoolID { get; set; }
        public School School { get; set; }

    }
}
