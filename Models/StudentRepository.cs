using System.Collections.Generic;
using System.Linq;

namespace StudentCourseRegistrationApp.Models
{
    /// <summary>
    /// Thread-safe in-memory repository for Student records.
    /// Demonstrates data handling without requiring an external database.
    /// </summary>
    public static class StudentRepository
    {
        private static readonly List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Tejas Andodariya",
                Email = "tejas.andodariya@marwadiuniversity.ac.in",
                Course = "B.Tech Computer Engineering",
                Semester = 5
            },
            new Student
            {
                Id = 2,
                Name = "Rahul Sharma",
                Email = "rahul.sharma@example.com",
                Course = "B.Tech Information Technology",
                Semester = 5
            },
            new Student
            {
                Id = 3,
                Name = "Priya Patel",
                Email = "priya.patel@example.com",
                Course = "B.Tech Computer Science (AI & ML)",
                Semester = 4
            }
        };

        private static int _nextId = 4;
        private static readonly object _lock = new object();

        public static List<Student> GetAll()
        {
            lock (_lock)
            {
                return _students.ToList();
            }
        }

        public static Student? GetById(int id)
        {
            lock (_lock)
            {
                return _students.FirstOrDefault(s => s.Id == id);
            }
        }

        public static void Add(Student student)
        {
            lock (_lock)
            {
                student.Id = _nextId++;
                _students.Add(student);
            }
        }
    }
}
