using Restaurant.Entities;
using System.Threading.Tasks;

namespace Restaurant.BLL.Infra
{
    public interface ILoginBLL
    {
        Task<Student> PostLoginAsync(long ra, string password);
    }
}
