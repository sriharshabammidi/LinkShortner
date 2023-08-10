using LinkShortner.Interfaces;
using LinkShortner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LinkShortner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinksController : Controller
    {
        private readonly ILinksService linksService;
        
        public LinksController(ILinksService linksService)
        {
            this.linksService = linksService;
        }

        [HttpPost()]
        public async Task<IActionResult> ShortenLink(LengthyUrl lengthyUrl)
        {
            return Ok(await linksService.ShortenLink(lengthyUrl.OriginalLink));
        }

        [HttpGet()]
        public async Task<IActionResult> Get(string identifier)
        {
            return Ok(await linksService.ExpandLink(identifier));
        }
    }
}
