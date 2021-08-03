using Repository.Repos.BookOneRepositorys;
using Repository.Repos.BookRepositorys;
using Repository.Repos.BookTwoRepositorys;
using Repository.Repos.ManuscriptRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
            BookRepository = new BookRepository(context);
            ManuscriptRepository = new ManuscriptRepository(context);
            BookOneRepository = new BookOneRepository(context);
            BookTwoRepository = new BookTwoRepository(context);

        }
        public IBookRepository BookRepository { get; private set; }
        public IManuscriptRepository ManuscriptRepository { get; private set; }
        public IBookOneRepository BookOneRepository { get; private set; }
        public IBookTwoRepository BookTwoRepository { get; private set; }


        public int Complete()
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        
    }
}
