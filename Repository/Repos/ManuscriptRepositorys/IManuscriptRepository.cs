using Repository.Models;

namespace Repository.Repos.ManuscriptRepositorys
{
    public interface IManuscriptRepository : IGenericRepository<Manuscript>
    {
        void InsertRaw(Manuscript m);
    }
}
