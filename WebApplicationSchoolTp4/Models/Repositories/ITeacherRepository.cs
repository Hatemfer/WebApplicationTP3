namespace WebApplicationSchoolTp4.Models.Repositories
{
    public interface ITeacherRepository
    {
        IList<Teacher> GetAll();
        Teacher GetById(int id);
        void Add(Teacher t);
        void Edit(Teacher t);
        void Delete(Teacher t);
        IList<Teacher> GetTeachersBySchoolID(int? schoolId);
        IList<Teacher> FindByName(string name);

    }
}
