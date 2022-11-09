using StudentCourseModel = CodingTest.Models.StudentCourse;

namespace CodingTest.Repositories.StudentCourse
{
    public interface IStudentCourseRepository
    {
        public Task<List<StudentCourseModel>> GetAllCoursesFromStudentId(int id);
        public Task CreateRangeStudentCourseAsync(List<StudentCourseModel> modelStudentCourse);
        public Task DeleteRangeStudentCourseAsync(List<StudentCourseModel> modelStudentCourse);
    }
}
