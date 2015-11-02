using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shorty.Data.DataObjects;

namespace Shorty.Data.Managers
{
    public class UrlManager
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
}
