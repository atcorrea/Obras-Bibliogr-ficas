using System.Collections.Generic;
using GuideTest.Models;

namespace GuideTest.Interfaces
{
    public interface IRepositoryService
    {
        IEnumerable<Author> GetAuthors();

        Author DeleteAuthorFromHistory(Author author);
    }
}