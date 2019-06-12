using Restaurant.Entities;
using System.Threading.Tasks;

namespace Restaurant.DAL.Infra
{
    public interface ILoginRepository
    {
        Task<Student> PostLoginAsync(long ra, string password);
    }
}
