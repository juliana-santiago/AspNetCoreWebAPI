using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository 
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Students
        Student[] GetAllStudents(bool includeTeacher = false);
        Student[] GetAllStudentsBySchoolSubject(int schoolSubjectId, bool includeTeacher = false);
        Student GetStudentById(int studentId, bool includeTeacher = false);

        //Teachers
        Teacher[] GetAllTeachers(bool includeStudents = false);
        Teacher[] GetAllTeachersBySchoolSubject(int schoolSubjectId, bool includeStudents = false);
        Teacher GetTeacherById(int teacherId, bool includeTeacher = false);

    }
}
