using GuideTest.Data;
using GuideTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return _context.Add(item).Entity;
        }
       
        public Author Get(Author item)
        {
            return _context.Authors.FirstOrDefault(x => x.Id == item.Id);
        }

        public Author GetWhere(Func<Author, bool> predicate)
        {
            return _context.Authors.FirstOrDefault(predicate);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public IEnumerable<Author> GetAllWhere(Func<Author, bool> predicate)
        {
            return _context.Authors.Where(predicate);
        }

        public Author Remove(Author item)
        {
            return _context.Remove(item).Entity;
        }

        public bool Commit()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
