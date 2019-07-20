using GuideTest.Interfaces;
using GuideTest.Models;
using GuideTest.Repository;
using System;
using System.Collections.Generic;

namespace GuideTest.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly AuthorRepository _repo;

        public RepositoryService(AuthorRepository repo)
        {
            _repo = repo;
        }

        public List<Author> GetAuthors()
        {
            throw new NotImplementedException();
        }
    }
}
