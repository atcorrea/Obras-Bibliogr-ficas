using System;
using System.Collections.Generic;
using GuideTest.Models;

namespace GuideTest.Interfaces
{
    public interface IRepositoryService
    {
        IEnumerable<Author> GetAuthors();

        Author GetAuthorWhere(Func<Author, bool> predicate);

        Author DeleteAuthorFromHistory(Author author);

        Author RegisterNewAuthorInHistory(Author newAuthorHistory);
    }
}