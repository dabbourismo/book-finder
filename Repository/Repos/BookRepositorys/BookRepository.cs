using Repository.Models;
using System.Linq;

namespace Repository.Repos.BookRepositorys
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext context;
        public BookRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

      
    }
}
