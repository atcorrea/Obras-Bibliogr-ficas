using GuideTest.Data;
using GuideTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideTest.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly GuideTestContext _context;

        public AuthorRepository(GuideTestContext context)
        {
            _context = context;
        }

        public Author Add(Author item)
        {
            throw new NotImplementedException();
        }
       
        public Author Get(Author item)
        {
            throw new NotImplementedException();
        }

        public Author GetWhere(Func<Author, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAllWhere(Func<Author, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Author Remove(Author item)
        {
            throw new NotImplementedException();
        }

        public bool Commit()
        {
            throw new NotImplementedException();
        }
    }
}
