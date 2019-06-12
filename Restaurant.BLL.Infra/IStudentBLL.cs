using Restaurant.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.BLL.Infra
{
    public interface IStudentBLL
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentAsync(long id);
        Task<Student> PostStudentAsync(Student student);
        Task<Student> PutStudentAsync(Student student);
    }
}
