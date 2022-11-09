using ModelCourse = CodingTest.Models.Course;

namespace CodingTest.Repositories.Course
{
    public interface ICourseRepository
    {
        public Task<List<ModelCourse>> GetAllCourses();
        public Task<ModelCourse> GetCourseById(int id);
        public Task CreateCourseAsync(ModelCourse course);
        public Task UpdateCourseAsync(ModelCourse course);
        public Task DeleteCourseAsync(ModelCourse course);
    }
}
