using Repository.Models;
using System.Linq;

namespace Repository.Repos.BookTwoRepositorys
{
    public class BookTwoRepository : GenericRepository<BookTwo>, IBookTwoRepository
    {
        private readonly ApplicationDbContext context;
        public BookTwoRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
      
    }
}
