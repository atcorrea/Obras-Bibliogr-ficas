using GuideTest.Interfaces;
using GuideTest.Models;
using GuideTest.Repository;
using System;
using System.Collections.Generic;

namespace GuideTest.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository<Author> _repo;

        public RepositoryService(IRepository<Author> repo)
        {
            _repo = repo;
        }

        public Author DeleteAuthorFromHistory(Author author)
        {
            var deleted = _repo.Remove(author);
            _repo.Commit();
            return deleted;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _repo.GetAll();
        }

        public Author GetAuthorWhere(Func<Author, bool> predicate)
        {
            return _repo.GetWhere(predicate);
        }

        public Author RegisterNewAuthorInHistory(Author newAuthorHistory)
        {
            var newAuthor = _repo.Add(newAuthorHistory);
            _repo.Commit();

            return newAuthor;
        }
    }
}
