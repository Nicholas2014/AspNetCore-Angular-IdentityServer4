using BlogDemo.Core.Interfaces;
using System.Threading.Tasks;

namespace BlogDemo.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;

        public UnitOfWork(BlogContext context)
        {
            _context = context;
        }
        #region Implementation of IUnitOfWork

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
