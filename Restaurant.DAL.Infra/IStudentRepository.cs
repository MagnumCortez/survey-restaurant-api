using Restaurant.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.DAL.Infra
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentAsync(long id);
        Task<Student> PostStudentAsync(Student student);
        Task<Student> PutStudentAsync(Student student);
    }
}
