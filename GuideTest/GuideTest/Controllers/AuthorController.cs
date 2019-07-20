using GuideTest.DTOs;
using GuideTest.Interfaces;
using GuideTest.Models;
using GuideTest.Utils;
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
            var formattedName = AbntFormatter.FormatName(nameInfo.NameString, nameInfo.NameCount);
            RegisterNewAuthorInHistory(nameInfo, formattedName);

            return new JsonResult(new { Name = formattedName });
        }

        [HttpGet]
        public IActionResult GetAuthorsHistory()
        {
            return Ok(_service.GetAuthors().ToList());
        }

        [HttpDelete]
        public IActionResult DeleteAuthorFromHistory([FromBody] AuthorRequestDto request)
        {
            var author = _service.GetAuthorWhere(x => x.Id == request.AuthorId);
            return Ok(_service.DeleteAuthorFromHistory(author));
        }

        private void RegisterNewAuthorInHistory(AuthorRequestDto nameInfo, string formattedName)
        {
            var newAuthorHistory = new Author()
            {
                NameString = nameInfo.NameString,
                AuthorName = formattedName
            };

            _service.RegisterNewAuthorInHistory(newAuthorHistory);
        }
    }
}
