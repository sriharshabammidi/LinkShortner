using LinkShortner.Models;
using System.Threading.Tasks;

namespace LinkShortner.Interfaces
{
    public interface ILinksService
    {
        Task<Link> ShortenLink(string originalURL);
        Task<Link> ExpandLink(string linkIdentifier);
    }
}
