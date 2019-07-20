using System.Collections.Generic;
using GuideTest.Models;

namespace GuideTest.Interfaces
{
    public interface IRepositoryService
    {
        List<Author> GetAuthors();
    }
}