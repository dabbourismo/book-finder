using Repository.Models;
using System.Linq;

namespace Repository.Repos.BookOneRepositorys
{
    public class BookOneRepository : GenericRepository<BookOne>, IBookOneRepository
    {
        private readonly ApplicationDbContext context;
        public BookOneRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
      
    }
}
