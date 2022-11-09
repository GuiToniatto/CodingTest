using StudentModel = CodingTest.Models.Student;

namespace CodingTest.Repositories.Student
{
    public interface IStudentRepository
    {
        public Task<List<StudentModel>> GetAllStudents();
        public Task<StudentModel> GetStudentById(int id);
        public Task<StudentModel> CreateStudentAsync(StudentModel student);
        public Task UpdateStudentAsync(StudentModel student);
        public Task DeleteStudentAsync(StudentModel student);
    }
}
