using GuideTest.DTOs;
using GuideTest.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GuideTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        // POST api/formatAuthor
        [HttpPost("formatAuthor")]
        public ActionResult FormatAuthorName([FromBody] FormatAuthorNameRequestDTO nameInfo)
        {
            var formattedName = AbntFormatter.FormatName(nameInfo.NameString, nameInfo.NameCount);
            return new JsonResult(new { Name = formattedName });
        }
    }
}
