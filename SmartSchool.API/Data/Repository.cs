using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<PageList<Student>> GetAllStudentsAsync(PageParams pageParams, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(a => a.StudentsSchoolSubjects)
                             .ThenInclude(stud => stud.SchoolSubject)
                             .ThenInclude(sub => sub.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
            {
                query = query.Where(student => student.Name
                                                    .ToUpper()
                                                    .Contains(pageParams.Name.ToUpper()) ||
                                           student.Surname
                                                    .ToUpper()
                                                    .Contains(pageParams.Name.ToUpper()));
            }

            if(pageParams.Registration > 0)
            {
                query = query.Where(student => student.Registration == pageParams.Registration);
            }

            if (pageParams.Active != null)
            {
                query = query.Where(student => student.Active == (pageParams.Active != 0));
            }

            return await PageList<Student>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
            //return await query.ToListAsync();
        }

        public Student[] GetAllStudents(bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(a => a.StudentsSchoolSubjects)
                             .ThenInclude(stud => stud.SchoolSubject)
                             .ThenInclude(sub => sub.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Student[] GetAllStudentsBySchoolSubject(int schoolSubjectId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(a => a.StudentsSchoolSubjects)
                             .ThenInclude(stud => stud.SchoolSubject)
                             .ThenInclude(sub => sub.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(student => student.StudentsSchoolSubjects.Any(subject => subject.SchoolSubjectId == schoolSubjectId));

            return query.ToArray();
        }

        public Student GetStudentById(int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(a => a.StudentsSchoolSubjects)
                             .ThenInclude(stud => stud.SchoolSubject)
                             .ThenInclude(sub => sub.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(student => student.Id == studentId);

            return query.FirstOrDefault();
        }

        public Teacher[] GetAllTeachers(bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.SchoolSubjects)
                             .ThenInclude(sub => sub.StudentsSchoolSubjects)
                             .ThenInclude(stud => stud.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(t => t.Id);

            return query.ToArray();
        }

        public Teacher[] GetAllTeachersBySchoolSubject(int schoolSubjectId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.SchoolSubjects)
                             .ThenInclude(sub => sub.StudentsSchoolSubjects)
                             .ThenInclude(stud => stud.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.SchoolSubjects
                             .Any(s => s.StudentsSchoolSubjects
                             .Any(sub => sub.SchoolSubjectId == schoolSubjectId)));

            return query.ToArray();
        }

        public Teacher GetTeacherById(int teacherId, bool includeTeacher = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeTeacher)
            {
                query = query.Include(t => t.SchoolSubjects)
                             .ThenInclude(sub => sub.StudentsSchoolSubjects)
                             .ThenInclude(stud => stud.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(t => t.Id)
                         .Where(teacher => teacher.Id == teacherId);

            return query.FirstOrDefault();
        }

    }
}
