using GuideTest.DTOs;
using GuideTest.Interfaces;
using GuideTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GuideTest.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IRepositoryService _service;

        public AuthorController(IRepositoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult FormatAuthorName([FromBody] AuthorRequestDto nameInfo)
        {
            var formattedName = Author.FormatName(nameInfo.NameString, nameInfo.NameCount);
            return Ok(RegisterNewAuthorInHistory(nameInfo, formattedName));
        }

        [HttpGet]
        public IActionResult GetAuthorsHistory()
        {
            return Ok(_service.GetAuthors().Reverse().Take(10).ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorFromHistory(int id)
        {
            var author = _service.GetAuthorWhere(x => x.Id == id);
            return Ok(_service.DeleteAuthorFromHistory(author));
        }

        private Author RegisterNewAuthorInHistory(AuthorRequestDto nameInfo, string formattedName)
        {
            var newAuthorHistory = new Author()
            {
                NameString = nameInfo.NameString,
                AuthorName = formattedName
            };

            return _service.RegisterNewAuthorInHistory(newAuthorHistory);
        }
    }
}
