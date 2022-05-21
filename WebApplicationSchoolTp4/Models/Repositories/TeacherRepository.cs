using Microsoft.EntityFrameworkCore;

namespace WebApplicationSchoolTp4.Models.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        readonly StudentContext context;
        public TeacherRepository(StudentContext context)
        {
            this.context = context;
        }
        public IList<Teacher> GetAll()
        {
            return context.Teachers.OrderBy(x => x.TeacherName).Include(x
            => x.School).ToList();
        }
        public Teacher GetById(int id)
        {
            return context.Teachers.Where(x => x.TeacherId == id).Include(x => x.School).SingleOrDefault();
        }
        public void Add(Teacher t)
        {
            context.Teachers.Add(t);
            context.SaveChanges();
        }
        public void Edit(Teacher t)
        {
            Teacher t1 = context.Teachers.Find(t.TeacherId);
            if (t1 != null)
            {
                t1.TeacherName = t.TeacherName;
                t1.Age = t.Age;
                t1.BirthDate = t.BirthDate;
                t1.SchoolID = t.SchoolID;
                context.SaveChanges();
            }
        }
        public void Delete(Teacher t)
        {
            Teacher t1 = context.Teachers.Find(t.TeacherId);
            if (t1 != null)
            {
                context.Teachers.Remove(t1);
                context.SaveChanges();
            }
        }
        public IList<Teacher> GetTeachersBySchoolID(int? schoolId)
        {
            return context.Teachers.Where(s =>
            s.SchoolID.Equals(schoolId))
            .OrderBy(s => s.TeacherName)
            .Include(std => std.School).ToList();
        }
        public IList<Teacher> FindByName(string name)
        {
            return context.Teachers.Where(s =>
            s.TeacherName.Contains(name)).Include(std =>
            std.School).ToList();
        }
    }
}
