using System.Data.Entity;
using System.Threading.Tasks;
using Shorty.Core.Data;
using Shorty.Data;

namespace Shorty.Core.Services
{
    public class ShortUrlService : ServiceBase
    {
        public async Task<string> GetLongUrl(string shortUrl)
        {
            using (var context = new AppDbContext())
            {
                var url = await context.Urls.FirstOrDefaultAsync(s => s.ShortUrl == shortUrl);

                if (url == null) return string.Empty;

                return url.FullUrl;
            }
        }
    }

    public class ServiceBase
    {
        public AppDbContext DbContext { get; set; }
    }
}
