using BalanceViewer.Data;

namespace BalanceViewer.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
