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
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IManuscriptRepository ManuscriptRepository { get; }
        IBookOneRepository BookOneRepository { get; }
        IBookTwoRepository BookTwoRepository { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
