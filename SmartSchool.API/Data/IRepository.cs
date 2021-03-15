using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IRepository 
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Students Async
        Task<PageList<Student>> GetAllStudentsAsync(PageParams pageParams, bool includeTeacher = false);

        //Students Sync
        Student[] GetAllStudents(bool includeTeacher = false);
        Student[] GetAllStudentsBySchoolSubject(int schoolSubjectId, bool includeTeacher = false);
        Student GetStudentById(int studentId, bool includeTeacher = false);

        //Teachers
        Teacher[] GetAllTeachers(bool includeStudents = false);
        Teacher[] GetAllTeachersBySchoolSubject(int schoolSubjectId, bool includeStudents = false);
        Teacher GetTeacherById(int teacherId, bool includeTeacher = false);

    }
}
