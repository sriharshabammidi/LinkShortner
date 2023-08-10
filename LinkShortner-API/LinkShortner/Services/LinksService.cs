using LinkShortner.Interfaces;
using LinkShortner.Models;
using System;
using System.Threading.Tasks;

namespace LinkShortner.Services
{
    public class LinksService: ILinksService
    {
        private readonly MongoDBService mongoDBService;
        
        public LinksService(MongoDBService mongoDBService)
        {
            this.mongoDBService = mongoDBService;
        }

        public async Task<Link> ExpandLink(string linkIdentifier)
        {
            var link = await mongoDBService.GetLinkByIdentifier(linkIdentifier);
            return link;
        }

        public async Task<Link> ShortenLink(string originalURL)
        {
            var link = new Link
            {
                LinkIdentifier = CreateString(8),
                Expiry = DateTime.Now.AddHours(1),
                OriginalLink = originalURL
            };
            await mongoDBService.CreateAsync(link);
            return link;
        }

        private static string CreateString(int stringLength)
        {
            Random rd = new();
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijlkmnopqrstuvwxyz0123456789";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
