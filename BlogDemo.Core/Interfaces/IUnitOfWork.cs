using System.Threading.Tasks;

namespace BlogDemo.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}