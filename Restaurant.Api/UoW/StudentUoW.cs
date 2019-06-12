using Restaurant.Api.UoW.Infra;
using Restaurant.BLL.Infra;

namespace Restaurant.Api.UoW
{
    public class StudentUoW : IStudentUoW
    {
        public IStudentBLL studentBLL { get; }

        public StudentUoW(IStudentBLL studentBLL)
        {
            this.studentBLL = studentBLL;
        }
    }
}
