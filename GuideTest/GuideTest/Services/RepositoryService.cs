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
            return _repo.Remove(author);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _repo.GetAll();
        }        
    }
}
