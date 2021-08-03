using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos.ManuscriptRepositorys
{
    class ManuscriptRepository : GenericRepository<Manuscript>, IManuscriptRepository
    {
        private readonly ApplicationDbContext context;
        public ManuscriptRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

        public void InsertRaw(Manuscript m)
        {
            context.Database.ExecuteSqlCommand($@"insert into Manuscripts
(ManuName,ManuAuther,ManuArt,ManuLiberaryName,ManuNumber1,ManuNumber2,ManuCountry
,ManuCopier,ManuCopyDate,ManuNumberOfPapers,ManuNotes,ManuLanguage,ManuFirst,
ManuLast,ManuDescription,ManuDataSource,,ManuFont,ManuInk,ManuPaperArea,ManuContentArea
,ManuNumberOfLines,ManuContentCondition) values ('{m.ManuName}',{m.ManuAuther}',{m.ManuArt}',
{m.ManuLiberaryName}',{m.ManuNumber1}',{m.ManuNumber2}',{m.ManuCountry}',
{m.ManuCopier}',{m.ManuCopyDate}',{m.ManuNumberOfPapers}',{m.ManuNotes}',{m.ManuLanguage}',{m.ManuFirst}'
,{m.ManuLast}',{m.ManuDescription}',{m.ManuDataSource}',{m.ManuFont}',{m.ManuInk}'
,{m.ManuPaperArea}',{m.ManuContentArea}',{m.ManuNumberOfLines}',{m.ManuContentCondition}')");
        }
    }
}
